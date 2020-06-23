using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FixesBusiness;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace FixesAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : FixesController
    {

        private readonly IUserService userService;

        public UserController()
        {
            userService = new UserService();
        }

        [HttpPost("findusers")]
        async public Task<string> FindUsers(StringQueryViewModel request)
        {
            var response = new APIResponseViewModel();

            var users = await userService.FindUsersByName(request.SearchParam);

            response.ResponseCode = (int)ResponseCode.Ok;
            response.Message = null;
            response.Error = false;
            response.ErrorList = null;

            return JsonConvert.SerializeObject(new { response, users });
        }

    }
}
