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

        public async Task<IEnumerable<ProductoCarrito>> GetCarritoAsync()
        {
            List<ProductoCarrito> response = new List<ProductoCarrito>();
            var Carro = await ProductosDelCarro();
            if (Carro != null)
            {
                foreach (var item in Carro)
                {
                    foreach (var producto in item.products)
                    {
                        var detalleProducto = await GetProductoPorId(producto.productId);
                        detalleProducto.CarritoId = item.id;
                        detalleProducto.idUsuarioCarrito = item.userId;
                        if (detalleProducto != null)
                        {
                           
                            response.Add(detalleProducto);
                        }
                    }
                }
                return response;
            }
            
            return default;
        }
        public async Task<IEnumerable<Carrito>> ProductosDelCarro()
        {
            var response = await client.GetAsync(Constants.CarritoEndPoint);
            if (response.IsSuccessStatusCode) return await response.Content.ReadFromJsonAsync<IEnumerable<Carrito>>(options);
            return Enumerable.Empty<Carrito>();
        }

        public async Task<ProductoCarrito> GetProductoPorId(int id)
        {
            var response = await client.GetAsync($"{Constants.ProductsEndpoint}/{id}");
            if (response.IsSuccessStatusCode) return await response.Content.ReadFromJsonAsync<ProductoCarrito>(options);
            return default;
        }
    }
}
