using PlataformaDesarrollo.Datos.Interfaces;
using PruebasRest.Entidades;
using PruebasRest.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PruebasRest.Data
{
    public class ClienteRepository : ICliente
    {
        private readonly IEjecutorDatos _context;

        public ClienteRepository(IEjecutorDatos context)
        {
            _context = context;
        }

        public IEnumerable<Cliente> ConsultarCliente()
        {
            _context.Modulo = "CLI";
            _context.CadenaConexion = "CadenaInfraestructura";          
            PlataformaDesarrollo.Datos.ParametrosEjecucion parametrosEjecucion = new PlataformaDesarrollo.Datos.ParametrosEjecucion();
            parametrosEjecucion.NombreProcedimiento = "pConsultaCliente";
            IEnumerable<Cliente> clientes = _context.ExecuteDataSet<Cliente>(parametrosEjecucion);
            return clientes;
        }
    }
}
