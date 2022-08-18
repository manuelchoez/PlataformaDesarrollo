using MicroServicioUsuario.Application.Services.Interfaces;
using MicroServicioUsuario.Dominio;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PlataformaDesarrollo.Servicio;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MicroServicioUsuario.API.Controllers
{
    [Route("api/usuario")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioService usuarioService;
        public UsuarioController(IUsuarioService usuarioService)
        {
            this.usuarioService = usuarioService;
        }

        [HttpPost]
        [Route("ConsultarColaboradorActivo")]       
        public async Task<ActionResult> ObtenerUsuario(Usuario usuario)
        {
            Response<Usuario> usuarioRes = await usuarioService.ObtenerUsuario(usuario);
            return StatusCode((int)usuarioRes.Status, usuarioRes);
        }
    }
}
