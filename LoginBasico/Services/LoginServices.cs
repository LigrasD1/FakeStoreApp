using LoginBasico.Models;
using System.Net.Http.Headers;
using System.Text.Json;
using LoginBasico.Utils;
using System.Net.Http.Json;
using System.Text;

namespace LoginBasico.Services
{
    public class LoginServices:ILoginServices
    {
        HttpClient client;

        private static JsonSerializerOptions options = new()
        {
            PropertyNameCaseInsensitive = true
        };
        public LoginServices()
        {
            client = new HttpClient();

            client.BaseAddress = new Uri(Constants.ApiDataServer);
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));
        }
        public async Task<HttpResponseMessage> RealizarLoginAsync(string username, string password)
        {
           // var response = await client.GetAsync(Constants.LoginEndpoint);

            Login loginData = new Login{ username = username, password = password };
            var content = new StringContent(JsonSerializer.Serialize(loginData), Encoding.UTF8, "application/json");

            var response = await client.PostAsync(Constants.LoginEndpoint, content);

            // Aquí no deserializamos directamente, sino que devolvemos el objeto HttpResponseMessage
            return response;
        }
    }
}
