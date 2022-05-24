using PruebasRest.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PruebasRest.Interfaces
{
   public interface ICredito
    {
        IEnumerable<Credito> ConsultarCreditos();
    }
}
