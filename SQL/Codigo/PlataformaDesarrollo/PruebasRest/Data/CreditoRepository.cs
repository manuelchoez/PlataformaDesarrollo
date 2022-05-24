using PlataformaDesarrollo.Datos.Interfaces;
using PruebasRest.Entidades;
using PruebasRest.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PruebasRest.Data
{
    public class CreditoRepository : ICredito
    {
        private readonly IEjecutorDatos _context;

        public CreditoRepository(IEjecutorDatos context)
        {
            _context = context;
        }
        public IEnumerable<Credito> ConsultarCreditos()
        {
            _context.Modulo = "CRE";
            _context.CadenaConexion = "CadenaInfraestructura";
            PlataformaDesarrollo.Datos.ParametrosEjecucion parametrosEjecucion = new PlataformaDesarrollo.Datos.ParametrosEjecucion();
            parametrosEjecucion.NombreProcedimiento = "pConsultarCredito";
            IEnumerable<Credito> creditos = _context.ExecuteDataSet<Credito>(parametrosEjecucion);
            return creditos;
        }
    }
}
