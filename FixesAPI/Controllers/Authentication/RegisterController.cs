using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FixesAPI.Mappers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using Model;
using Service;
using Service.Interfaces;
using FixesAPI.Validators;
using Newtonsoft.Json;

namespace FixesAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RegisterController : FixesController
    {

        private readonly IAuthenticationService authService;
        private readonly RegisterValidator registerValidator;

        public RegisterController()
        {
            authService = new AuthenticationService();
            registerValidator = new RegisterValidator();
        }

        [HttpPost]
        public string Register(AuthenticationViewModel user)
        {

            var response = new APIResponseViewModel();

            var validation = registerValidator.IsValid(user);

            if (!validation.Error) 
            {
                try
                {
                    var u = authService.Register(UserMapper.Map(user));
                    response.ResponseCode = (int)ResponseCode.Ok;
                    response.Message = new Dictionary<string, object>() { { "user", u.UserName } };
                    response.Error = false;
                }
                catch(Exception e)
                {
                    response.ResponseCode = (int)ResponseCode.ServerError;
                    response.Error = true;
                    response.ErrorList = new Dictionary<string, string>() { { "msg", e.InnerException.ToString() } };
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
    }
}



