using PlataformaDesarrollo.Datos.Interfaces;
using Pruebas.Entidades;
using Pruebas.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pruebas.Data
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
            _context.CadenaConexion = "CadenaInfraestructura";
            _context.Modulo = "CLI";
            PlataformaDesarrollo.Datos.ParametrosEjecucion parametrosEjecucion = new PlataformaDesarrollo.Datos.ParametrosEjecucion();
            parametrosEjecucion.NombreProcedimiento = "pConsultaCliente";
            IEnumerable<Cliente> clientes = _context.ExecuteDataSet<Cliente>(parametrosEjecucion);
            return clientes;
        }
    }
}
