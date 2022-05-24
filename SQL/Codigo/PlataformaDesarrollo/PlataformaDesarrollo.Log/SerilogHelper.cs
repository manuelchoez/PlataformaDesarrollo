using Microsoft.Extensions.Configuration;
using PlataformaDesarrollo.Datos;
using Serilog;
using Serilog.Sinks.MSSqlServer;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlataformaDesarrollo.Logging
{
    public class SerilogHelper
    {
        private readonly IConfiguration _configuration;

        public SerilogHelper(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        /// <summary>
        ///  Parametros de configuracion para crear log en base de datos
        /// </summary>
        /// <param name="connectionString">cadena conexion donde se registra el log</param>
        /// <returns>SinkOptions</returns>
        public SinkOptions ConfigureMSSqlServerSinkOptions(string connectionString)
        {
            string cadenaConexion = Encriptador.Desencriptar(_configuration.GetSection(ConstantesLoggin.ConexionLog).Value);
            string nombreBaseDatos = Encriptador.Desencriptar(_configuration.GetSection(ConstantesLoggin.BaseDatos).Value);
            string nombreTabla = Encriptador.Desencriptar(_configuration.GetSection(ConstantesLoggin.Tabla).Value);
            int batchPostingLimit = int.Parse(_configuration.GetSection(ConstantesLoggin.BatchPostingLimit).Value);
            TimeSpan batchPeriod = TimeSpan.Parse(_configuration.GetSection(ConstantesLoggin.BatchPeriod).Value);
            SinkOptions serilogSinkOptions = new SinkOptions();
            serilogSinkOptions.NombreBaseDatos = nombreBaseDatos;
            serilogSinkOptions.CadenaConexion = cadenaConexion;
            serilogSinkOptions.SqlServerSinkOptions = new MSSqlServerSinkOptions();
            serilogSinkOptions.SqlServerSinkOptions.TableName = nombreTabla;
            serilogSinkOptions.SqlServerSinkOptions.AutoCreateSqlTable = false;
            serilogSinkOptions.SqlServerSinkOptions.BatchPostingLimit = batchPostingLimit;
            serilogSinkOptions.SqlServerSinkOptions.BatchPeriod = batchPeriod;
            serilogSinkOptions.ColumnOptions = new ColumnOptions
            {
                AdditionalColumns = new Collection<SqlColumn>
               {
                   new SqlColumn(ConstantesLoggin.Aplicacion, SqlDbType.VarChar)
               }
            };
            return serilogSinkOptions;
        }

        /// <summary>
        /// Configuracion Serilog
        /// </summary>
        /// <param name="nombreAplicacion">>Nombre aplicacion a configurar</param>
        /// <param name="connectionString"></param>
        /// <returns>LoggerConfiguration</returns>
        public LoggerConfiguration SerilogConfigure(string nombreAplicacion, string connectionString)
        {
            SinkOptions sinkOptions = ConfigureMSSqlServerSinkOptions(connectionString);
            return new LoggerConfiguration().MinimumLevel.Warning()
                .Enrich.FromLogContext()
                .Enrich.FromLogContext()
                .Enrich.WithCorrelationId()
                .Enrich.WithClientIp()
                .Enrich.WithClientAgent()
                .Enrich.WithProperty(ConstantesLoggin.Aplicacion, nombreAplicacion)
                .WriteTo.MSSqlServer(sinkOptions.CadenaConexion, sinkOptions: sinkOptions.SqlServerSinkOptions, columnOptions: sinkOptions.ColumnOptions);
        }
    }
}
