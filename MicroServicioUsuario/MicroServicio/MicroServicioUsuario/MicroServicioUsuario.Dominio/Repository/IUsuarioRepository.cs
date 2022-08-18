using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MicroServicioUsuario.Dominio.Repository
{
    public interface IUsuarioRepository
    {
        public Task<Usuario> ObtenerUsuario(Usuario usuario);        

    }
}
