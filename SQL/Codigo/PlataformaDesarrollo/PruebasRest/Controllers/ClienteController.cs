using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PruebasRest.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PruebasRest.Controllers
{
    [Route("api/cliente")]
    [ApiController]
    public class ClienteController : ControllerBase
    {
        private readonly ICliente _cliente;
        private readonly ICredito _credito;

        public ClienteController(ICliente cliente, ICredito credito)
        {
            _cliente = cliente;
            _credito = credito;
        }

        [HttpPost]
        [Route("BuscarCliente")]
        public ActionResult BuscarCliente()
        {
            var objClientes = _cliente.ConsultarCliente();
            var objCredito = _credito.ConsultarCreditos();
            return StatusCode(200, objClientes);
        }

    }
}
