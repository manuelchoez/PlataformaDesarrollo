using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PruebasRest.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Serilog;
namespace PruebasRest.Controllers
{
    [Route("api/cliente")]
    [ApiController]
    public class ClienteController : ControllerBase
    {
        private readonly ICliente _cliente;
        private readonly ICredito _credito;
        private readonly ILogger _logger;
        public ClienteController(ICliente cliente, ICredito credito, ILogger logger)
        {
            _cliente = cliente;
            _credito = credito;
            _logger = logger;
        }

        [HttpPost]
        [Route("BuscarCliente")]
        public ActionResult BuscarCliente()
        {
            var objClientes = _cliente.ConsultarCliente();
            var objCredito = _credito.ConsultarCreditos();
            _logger.Warning("Esto es una prueba");
            return StatusCode(200, objClientes);
        }

    }
}
