using Serilog.Sinks.MSSqlServer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlataformaDesarrollo.Logging
{
    public class SinkOptions
    {
        public string NombreBaseDatos { get; set; }
        public string CadenaConexion { get; set; }
        public MSSqlServerSinkOptions SqlServerSinkOptions { get; set; }
        public ColumnOptions ColumnOptions { get; set; }
        public string ArchivoLog { get; set; }
    }
}
