using Pruebas.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pruebas.Interfaces
{
   public  interface ICliente
    {
        IEnumerable<Cliente> ConsultarCliente();
    }
}
