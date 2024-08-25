using LoginBasico.Models;
using System.Net.Http.Headers;
using System.Text.Json;
using LoginBasico.Utils;
using System.Net.Http.Json;

namespace LoginBasico.Services
{
    public class ProductoServices : IProductoServices
    {
        HttpClient client;

        private static JsonSerializerOptions options = new()
        {
            PropertyNameCaseInsensitive = true
        };

        public ProductoServices()
        {
            client = new HttpClient();

            client.BaseAddress = new Uri(Constants.ApiDataServer);
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));
        }
        

        public async Task<IEnumerable<Producto>> GetProductsAsync()
        {
            var response = await client.GetAsync(Constants.ProductsEndpoint);

            if (response.IsSuccessStatusCode)
                return await response.Content.ReadFromJsonAsync<IEnumerable<Producto>>(options);

            return default;
        }

    }
}
