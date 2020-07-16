using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using static System.Diagnostics.Debug;

namespace TestAPI
{
    class FindUsers
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
                    SearchParam = "a",
                };

                string body = JsonConvert.SerializeObject(oBody, Formatting.Indented);

                var stringTask = client.GetAsync(Program.baseURL + "/api/user/findusers/?username=s");

                var msg = await stringTask;

                Assert(msg.IsSuccessStatusCode, "HTTP Error code");

                var jsonString = msg.Content.ReadAsStringAsync().Result.Replace("\\", "").Trim('"');

                Console.WriteLine(jsonString);

                var response = JsonConvert.DeserializeObject<Program.Response>(jsonString);

                Assert(!response.Error, "Error searching users");

            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
