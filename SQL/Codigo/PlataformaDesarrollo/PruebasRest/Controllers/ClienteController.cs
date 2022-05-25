using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PruebasRest.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Serilog;
using PlataformaDesarrollo.Cache.Interfaces;
using PruebasRest.Entidades;
using System.Text.Json;

namespace PruebasRest.Controllers
{
    [Route("api/cliente")]
    [ApiController]
    public class ClienteController : ControllerBase
    {
        private readonly ICliente _cliente;
        private readonly ICredito _credito;
        private readonly ILogger _logger;
        private readonly IPlataformaCache _plataformaCache;
        public ClienteController(ICliente cliente, ICredito credito, ILogger logger, IPlataformaCache plataformaCache)
        {
            _cliente = cliente;
            _credito = credito;
            _logger = logger;
            _plataformaCache = plataformaCache;
        }

        [HttpPost]
        [Route("BuscarCliente")]
        public async Task<IActionResult> BuscarCliente()
        {
            IEnumerable<Cliente> objClientes = null;
            string resultado = await _plataformaCache.Obtener("objClientes");

            if (string.IsNullOrEmpty(resultado))
            {
                objClientes = _cliente.ConsultarCliente();
                await _plataformaCache.Agregar("objClientes", JsonSerializer.Serialize(objClientes));
            }                       
            else
            {               
                objClientes = JsonSerializer.Deserialize<IEnumerable<Cliente>>(resultado);
            }            
            var objCredito = _credito.ConsultarCreditos();
            _logger.Warning("Esto es una prueba");
            return StatusCode(200, objClientes);
        }

    }
}
