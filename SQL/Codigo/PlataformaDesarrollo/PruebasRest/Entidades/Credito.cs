using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PruebasRest.Entidades
{
    public class Credito
    {
        public int IdCredito { get; set; }
        public string NumeroCredito { get; set; }
        public decimal Monto { get; set; }
        public int IdCliente { get; set; }
    }
}
