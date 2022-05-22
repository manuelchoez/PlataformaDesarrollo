using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlataformaDesarrollo.Entidades
{
    public class Conexion
    {
        public int IdConexion { get; set; }
        public string Modulo { get; set; }
        public string Fuente { get; set; }
        public string Proveedor { get; set; }
        public string Autenticacion { get; set; }
        public string Usuario { get; set; }
        public string Clave { get; set; }
        public string NombreBaseDeDatos { get; set; }
        public string Modelo { get; set; }
    }
}
