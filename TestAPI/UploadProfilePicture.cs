using Newtonsoft.Json;
using System;
using System.IO;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using static System.Diagnostics.Debug;

namespace TestAPI
{
    class UploadProfilePicture
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

                var content = new MultipartFormDataContent();

                string path = "resources/mimann.jpg";

                var picture = new FileStream(path, FileMode.Open);

                content.Add(new StreamContent(picture),
                    "Image",
                    path);

                var task = await client.PostAsync(Program.baseURL + "/api/user/uploadprofilepicture", content);

                var jsonString = task.Content.ReadAsStringAsync().Result.Replace("\\", "").Trim('"');

                Console.WriteLine(jsonString);

                var response = JsonConvert.DeserializeObject<Program.Response>(jsonString);

            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }
    }
}
