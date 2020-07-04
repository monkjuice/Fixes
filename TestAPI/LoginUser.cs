using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace TestAPI
{
    class LoginUser
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

                var user = new
                {
                    Username = "Starlight",
                    Password = "wipididu",
                };

                string body = JsonConvert.SerializeObject(user, Formatting.Indented);

                var stringTask = client.PostAsync(Program.baseURL + "/login", new StringContent(body, Encoding.UTF8, "application/json"));

                var msg = await stringTask;

                var jsonString = msg.Content.ReadAsStringAsync().Result.Replace("\\", "").Trim('"');

                Console.WriteLine(msg.StatusCode);

                Console.WriteLine(jsonString);

                var response = JsonConvert.DeserializeObject<Program.Response>(jsonString);

                Program.userToken = response.Message["_token"].ToString();

            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
