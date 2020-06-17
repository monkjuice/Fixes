using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using static System.Diagnostics.Debug;

namespace TestAPI
{
    class CreateFriendshipRequest
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

                var oBody = new
                {
                    ToUserId = 2,
                };

                string body = JsonConvert.SerializeObject(oBody, Formatting.Indented);

                var stringTask = client.PostAsync(Program.baseURL + "/api/friendship/createrequest", new StringContent(body, Encoding.UTF8, "application/json"));

                var msg = await stringTask;

                Assert(msg.IsSuccessStatusCode, "HTTP Error code");

                var jsonString = msg.Content.ReadAsStringAsync().Result.Replace("\\", "").Trim('"');

                var response = JsonConvert.DeserializeObject<Program.Response>(jsonString);

                //Assert(response.Error, "Error creating friendship request");

                Console.WriteLine(jsonString);

            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
