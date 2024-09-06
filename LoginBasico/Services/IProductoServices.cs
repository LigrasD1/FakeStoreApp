using LoginBasico.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoginBasico.Services
{
    public interface IProductoServices
    {
       public Task<IEnumerable<Producto>> GetProductsAsync();
       public Task<IEnumerable<ProductoCarrito>> GetCarritoAsync();
    }
}
