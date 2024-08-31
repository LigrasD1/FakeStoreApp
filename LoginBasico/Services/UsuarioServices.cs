using LoginBasico.Models;
using System.Net.Http.Headers;
using System.Text.Json;
using LoginBasico.Utils;
using System.Net.Http.Json;

namespace LoginBasico.Services
{
    public class UsuarioServices :IUsuarioServices
    {
        HttpClient client;

        private static JsonSerializerOptions options = new()
        {
            PropertyNameCaseInsensitive = true
        };

        public UsuarioServices()
        {
            client = new HttpClient();

            client.BaseAddress = new Uri(Constants.ApiDataServer);
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));
        }


        public async Task<IEnumerable<Usuario>> GetUsuarioAsync()
        {
            var response = await client.GetAsync(Constants.UsuarioEndpoint);

            if (response.IsSuccessStatusCode)
                return await response.Content.ReadFromJsonAsync<IEnumerable<Usuario>>(options);

            return default;
        }

        public async Task<Usuario> PedirUsuario(int id)
        {
            
            try
            {
                string endpoint = $"{Constants.UsuarioEndpoint}/{id}";
                var response = await client.GetAsync(endpoint);
                response.EnsureSuccessStatusCode();
                var jsonString = await response.Content.ReadAsStringAsync();
                Usuario usuario = JsonSerializer.Deserialize<Usuario>(jsonString, options);
                return usuario;

            }
            catch (HttpRequestException ex)
            {

                return null;
            }
        }

    }
}
