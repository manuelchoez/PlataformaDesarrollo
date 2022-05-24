using PlataformaDesarrollo.Datos.Interfaces;
using Pruebas.Interfaces;
using System;
using System.Collections.Generic;

namespace Pruebas
{
     class Program
    {

        private static readonly ICliente _cliente;

        static Program(ICliente cliente)
        {
            _cliente = cliente;
        }

        static void Main(string[] args)
        {
            _cliente.ConsultarCliente();
        }
    }        
}
