using MicroServicioUsuario.Dominio;
using PlataformaDesarrollo.Servicio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MicroServicioUsuario.Application.Services.Interfaces
{
    public interface IUsuarioService
    {
        Task<Response<Usuario>> ObtenerUsuario(Usuario usuario);
    }
}
