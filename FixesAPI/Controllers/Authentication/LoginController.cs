﻿using System;
using FixesAPI.Mappers;
using Microsoft.AspNetCore.Mvc;
using Model;
using Service;
using Service.Interfaces;
using FixesAPI.Validators;
using Newtonsoft.Json;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.Extensions.Configuration;
using System.Security.Claims;
using System.Collections.Generic;
using Repository.ViewModels;

namespace FixesAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LoginController : FixesController
    {

        private readonly IAuthenticationService authService;
        private readonly LoginValidator loginValidator;
        private IConfiguration _config;

        public LoginController(IConfiguration config)
        {
            authService = new AuthenticationService();
            loginValidator = new LoginValidator();
            _config = config;
        }

        [HttpPost]
        public string Login(AuthenticationViewModel loginForm)
        {
            var response = new APIResponseViewModel();

            var validation = loginValidator.IsValid(loginForm);

            if (!validation.Error) 
            {
                try
                {
                    var user = authService.Login(UserMapper.Map(loginForm));

                    var tokenString = GenerateJWT(user);

                    response.ResponseCode = (int)ResponseCode.Ok;

                    response.Message = new Dictionary<string, object>() { { "_token", tokenString }, { "User", user } };

                    response.Error = false;
                }
                catch(Exception e)
                {
                    response.ResponseCode = (int)ResponseCode.ServerError;
                    response.Error = true;
                }
            }
            else
            {
                response.ResponseCode = (int)ResponseCode.BadRequest;
                response.Error = true;
                response.ErrorList = validation.ErrorList;
            }

            return JsonConvert.SerializeObject(response);
        }

        private string GenerateJWT(UserViewModel user)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var permClaims = new List<Claim>();
            permClaims.Add(new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()));
            permClaims.Add(new Claim("userid", user.UserId.ToString()));
            permClaims.Add(new Claim("username", user.Username));

            var token = new JwtSecurityToken(
                _config["Jwt:Issuer"],
                _config["Jwt:Audience"],
                permClaims,
                expires: DateTime.Now.AddMinutes(120),
                signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}



