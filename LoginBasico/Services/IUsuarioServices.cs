using LoginBasico.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoginBasico.Services
{
    public interface IUsuarioServices
    {
        public Task<IEnumerable<Usuario>> GetUsuarioAsync();
        public Task<Usuario> PedirUsuario(int id);

    }
}
