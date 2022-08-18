using MicroServicioUsuario.Application.Services.Interfaces;
using MicroServicioUsuario.Dominio;
using MicroServicioUsuario.Dominio.Repository;
using PlataformaDesarrollo.Servicio;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MicroServicioUsuario.Application.Services
{
    public class UsuarioService : IUsuarioService
    {
        private readonly ILogger _logger;
        private readonly IUsuarioRepository _usuarioRepository;
        public UsuarioService(ILogger logger, IUsuarioRepository usuarioRepository)
        {
            _logger = logger;
            _usuarioRepository = usuarioRepository;
        }

        public async Task<Response<Usuario>> ObtenerUsuario(Usuario usuario)
        {
            try
            {
                Usuario usuarioRespuesta = await _usuarioRepository.ObtenerUsuario(usuario);
                return Response<Usuario>.Ok(usuarioRespuesta, Constantes.Constantes.MensajeSolicitudProcesoCorrectamente);
            }
            catch (Exception ex)
            {
                _logger.Error(ex, "Error ObtenerUsuario");
                return Response<Usuario>.Error(ex);
            }
        }


    }
}
