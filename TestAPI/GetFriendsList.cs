using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace TestAPI
{
    class GetFriendsList
    {
        private static readonly HttpClient client = new HttpClient();

        async static public Task Execute()
        {
            try
            {
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(
                    new MediaTypeWithQualityHeaderValue("application/json"));
                client.DefaultRequestHeaders.Add("User-Agent", ".NET Foundation Repository Reporter");

                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", Program.userToken);

                var stringTask = client.GetAsync(Program.baseURL + "/api/friendship/friendslist?userId=1");

                var msg = await stringTask;

                var jsonString = msg.Content.ReadAsStringAsync().Result.Replace("\\", "").Trim('"');

                var response = JsonConvert.DeserializeObject<Program.Response>(jsonString);

                if(response.Error == false)
                {
                    var friends = JsonConvert.DeserializeObject<List<Models.UserProfile>>(response.Message["Friends"].ToString());
                    Console.WriteLine(friends);
                }

            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
