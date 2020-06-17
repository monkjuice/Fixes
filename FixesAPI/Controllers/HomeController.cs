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
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;

namespace FixesAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class HomeController : ControllerBase
    {

        public HomeController()
        {
        }

        [HttpGet]
        public string Index()
        {
            var user = HttpContext.User;

            IEnumerable<Claim> claims = user.Claims;

            return HttpContext.User.Claims.FirstOrDefault(x => x.Type == "username").Value;
        }
    }
}



