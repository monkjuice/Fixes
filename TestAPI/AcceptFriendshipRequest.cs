using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using static System.Diagnostics.Debug;

namespace TestAPI
{
    class AcceptFriendshipRequest
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
                    RequestId = 22,
                };

                string body = JsonConvert.SerializeObject(oBody, Formatting.Indented);

                var stringTask = client.PostAsync(Program.baseURL + "/api/friendship/acceptrequest", new StringContent(body, Encoding.UTF8, "application/json"));

                var msg = await stringTask;

                Assert(msg.IsSuccessStatusCode, "HTTP Error code");

                var jsonString = msg.Content.ReadAsStringAsync().Result.Replace("\\", "").Trim('"');

                var response = JsonConvert.DeserializeObject<Program.Response>(jsonString);

                Console.WriteLine(jsonString);

                //Assert(response.Error, "Error Accepting friendship request");

            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
