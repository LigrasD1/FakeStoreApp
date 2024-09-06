using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoginBasico.Models
{
    public class ProductoCarritoRating
    {
        public int count { get; set; }
        public float rate { get; set; }
    }
    public class ProductoCarrito
    {
        public int idUsuarioCarrito { get; set; }
        public int CarritoId { get; set; }
        public int id { get; set; }
        public string? title { get; set; }
        public double? price { get; set; }
        public string? description { get; set; }
        public string? category { get; set; }
        public string? image { get; set; }
        public Rating? rating { get; set; }
    }
}
