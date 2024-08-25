using LoginBasico.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoginBasico.Services
{
    public interface ILoginServices
    {

        public Task<HttpResponseMessage> RealizarLoginAsync(string username, string password);
    }
}
