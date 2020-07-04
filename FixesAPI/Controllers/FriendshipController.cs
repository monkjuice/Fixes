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
using Microsoft.AspNetCore.Http;
using FixesBusiness;

namespace FixesAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class FriendshipController : FixesController
    {
        
        private readonly IFriendshipService friendshipService;

        public FriendshipController()
        {
            friendshipService = new FriendshipService();
        }

        [HttpPost("createrequest")]
        async public Task<string> CreateRequest(CreateFriendshipRequestViewModel request)
        {
            var response = new APIResponseViewModel();

            var user = HttpContext.User;
            IEnumerable<Claim> claims = user.Claims;

            int userId = int.Parse(claims.First(x => x.Type == "userid").Value);

            var friendship = await friendshipService.CreateRequest(userId, request.ToUserId);

            if (friendship == true)
            {
                response.ResponseCode = (int)ResponseCode.Ok;
                response.Message = new Dictionary<string, object>() { { "Yay", "Friendship Sent!" } };
                response.Error = false;
            }
            else
            {
                response.ResponseCode = (int)ResponseCode.BadRequest;
                response.Error = true;
                response.ErrorList = new Dictionary<string, string>() { { "Error", "Friendship was not sent!" } }; ;
            }

            return JsonConvert.SerializeObject(response);
        }

        [HttpPost("acceptrequest")]
        async public Task<string> AcceptRequest(AcceptFriendshipViewModel request)
        {
            var response = new APIResponseViewModel();

            var friendship = await friendshipService.AcceptRequest(request.RequestId);

            if (friendship == true)
            {
                response.ResponseCode = (int)ResponseCode.Ok;
                response.Message = new Dictionary<string, object>() { { "Yay", "New friendship!" } };
                response.Error = false;
            }
            else
            {
                response.ResponseCode = (int)ResponseCode.BadRequest;
                response.Error = true;
                response.ErrorList = new Dictionary<string, string>() { { "Error", "Friendship was not saved!" } }; ;
            }

            return JsonConvert.SerializeObject(response);
        }

        [HttpGet("friendslist")]
        async public Task<string> GetFriendsList(int userId)
        {
            var response = new APIResponseViewModel();

            var friendsList = await friendshipService.GetFriendsList(userId);

            response.ResponseCode = (int)ResponseCode.Ok;
            response.Message = new Dictionary<string, object>() { { "Friends", friendsList } };
            response.Error = false;

            return JsonConvert.SerializeObject(response);
        }
    }
}



