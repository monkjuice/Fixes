using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace TestAPI
{
    class Program
    {
        public static string baseURL = "https://localhost:44338";
        public static string userToken;

        public class Response
        {
            public string ResponseCode { get; set; }
            public IDictionary<string, object> Message { get; set; }
            public bool Error { get; set; }
            public Dictionary<string,string> ErrorList { get; set; }
        }

        static async Task Main(string[] args)
        {
            if (args.Length > 1)
                baseURL = "https://fixesapi-dev.azurewebsites.net/"; 

            await CreateUser.Execute();
            await LoginUser.Execute();
            await HomeIndex.Execute();
            await CreateFriendshipRequest.Execute();
            await AcceptFriendshipRequest.Execute();
            await FindUsers.Execute();
            await UploadProfilePicture.Execute();
            await UserProfile.Execute();
            await GetFriendsList.Execute();
            await SignalR.Execute();

            Console.WriteLine("API Tests passed succesfully");
        }
    }
}
