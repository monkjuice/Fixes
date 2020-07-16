using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FixesAPI.Validators;
using FixesAPI.ViewModels.Requests;
using FixesAPI.ViewModels.Response;
using FixesBusiness;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace FixesAPI.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : FixesController
    {

        private readonly IUserService userService;

        public UserController()
        {
            userService = new UserService();
        }

        [HttpGet("profile")]
        async public Task<string> GetUserProfile(int userId)
        {
            var response = new GetUserProfileResponse();

            var profile = await userService.GetUserProfile(userId);

            if (profile != null)
            {
                response.ResponseCode = (int)ResponseCode.Ok;
                response.Error = false;
                response.Message = new Dictionary<string, object>() { { "Profile", profile } };
            }
            else
            {
                response.ResponseCode = (int)ResponseCode.BadRequest;
                response.Error = true;
                response.ErrorList = new Dictionary<string, string>() { { "Error", "User not found" } };
            }

            return JsonConvert.SerializeObject(response);
        }

        [HttpPost("uploadprofilepicture")]
        async public Task<string> UploadProfilePicture(IFormFile image)
        {
            var response = new APIResponseViewModel();

            try
            {
                var validator = new ValidateImage();
                if (!validator.IsValid(image))
                    return "stupid donkey";

                Console.WriteLine(image.ContentType);

                var file = image.OpenReadStream();

                int userId = int.Parse(HttpContext.User.Claims.FirstOrDefault(x => x.Type == "userid").Value);

                string path = await userService.UploadProfilePicture(file, userId);

                if (path != null)
                {
                    response.ResponseCode = (int)ResponseCode.Ok;
                    response.Error = false;
                    response.Message = new Dictionary<string, object>() { { "path",  path } };
                }
                else
                {
                    response.ResponseCode = (int)ResponseCode.BadRequest;
                    response.Error = true;
                    response.ErrorList = new Dictionary<string, string>() { { "Error", "Profile picture did not upload correctly." } };
                }
            }
            catch (Exception e)
            {
                response.ResponseCode = (int)ResponseCode.ServerError;
                response.Error = true;
                response.ErrorList = new Dictionary<string, string>() { { "Error", "Profile picture did not upload correctly." } };
                return JsonConvert.SerializeObject(response);
            }

            return JsonConvert.SerializeObject(response);
        }

        [HttpGet("findusers")]
        async public Task<string> FindUsers(string username)
        {
            var response = new APIResponseViewModel();

            var users = await userService.FindUsersByName(username);

            response.Message = new Dictionary<string, object>() { { "Users", users } };
            response.ResponseCode = (int)ResponseCode.Ok;
            response.Error = false;

            return JsonConvert.SerializeObject(response);
        }

    }
}
