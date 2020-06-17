using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace TestAPI
{
    class CreateUser
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

                var oBody = new
                {
                    Username = "Starlight",
                    Password = "wipididu",
                };

                string body = JsonConvert.SerializeObject(oBody, Formatting.Indented);

                var stringTask = client.PostAsync(Program.baseURL + "/register", new StringContent(body, Encoding.UTF8, "application/json"));

                var msg = await stringTask;

                Console.WriteLine(msg.Content.ReadAsStringAsync().Result);

            }
            catch (Exception e)
            {
                throw e;
            }
        }

    }
}
