using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace TestAPI
{
    class UserProfile
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

                var stringTask = client.GetAsync(Program.baseURL + "/api/user/profile");

                var msg = await stringTask;

                var jsonString = msg.Content.ReadAsStringAsync().Result.Replace("\\", "").Trim('"');

                var response = JsonConvert.DeserializeObject<Program.Response>(jsonString);

                if(response.Error == false)
                {
                    var profile = JsonConvert.DeserializeObject<Models.UserProfile>(response.Message["Profile"].ToString());
                }

            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
