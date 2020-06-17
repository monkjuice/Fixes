using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace TestAPI
{
    class HomeIndex
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

                var stringTask = client.GetAsync(Program.baseURL + "/api/home");

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
