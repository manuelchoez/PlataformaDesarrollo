using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using PlataformaDesarrollo.Datos.Interfaces;
using PlataformaDesarrollo.Entidades;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlataformaDesarrollo.Datos
{
    public class EjecutorDatos : IEjecutorDatos
    {
        private readonly IConfiguration _configuration;
        private string cadenaConexion = string.Empty;
        private string modulo = string.Empty;
        private static Dictionary<string, string> _dictCadenaConexion = new Dictionary<string, string>();
        private object _lock = new object();
        private SqlParametrosDapper[] parametrosSalida;
        private int timeOut;
        private int numeroParametrosOut;
        public int TimeOut
        {
            get
            {
                return timeOut;
            }
        }

        public SqlParametrosDapper[] OutParametro
        {
            get
            {
                return (SqlParametrosDapper[])parametrosSalida.Clone();
            }
            set
            {
                parametrosSalida = value;
            }
        }


        public string CadenaConexion
        {
            get
            {
                return cadenaConexion;
            }
            set
            {
                if (!_dictCadenaConexion.ContainsKey(value))
                {
                    lock (_lock)
                    {
                        if (!_dictCadenaConexion.ContainsKey(value))
                        {
                            if (_configuration.GetConnectionString(value) != null)
                            {
                                _dictCadenaConexion.Add(value, Encriptador.Desencriptar(_configuration.GetConnectionString(value)));
                                _dictCadenaConexion.Add(ConstantesEjecutorDatos.TimeOut, _configuration.GetSection(ConstantesEjecutorDatos.TimeOut).Value);
                            }
                            else
                            {
                                throw new ArgumentException(string.Format(ConstantesEjecutorDatos.ErrorCadenaConexion), value);
                            }
                        }
                    }
                }

                Conexion cadena = ProveedorCadenaConexion.ObtenerCadenaConexion(modulo, _dictCadenaConexion[value]);               
                cadenaConexion = ProveedorCadenaConexion.ConstruirConfiguracionCadena(cadena); 
                timeOut = int.Parse(_dictCadenaConexion[ConstantesEjecutorDatos.TimeOut]);
            } 
        }


        public string Modulo
        {
            get {
                return modulo;
            }
            set
            {
                modulo = value;
            }
        }

        private DynamicParameters AgregarParametrosConexion(SqlParametrosDapper[] parametros)
        {
            try
            {
                DynamicParameters dynamicParameters = new DynamicParameters();
                if (parametros != null)
                {
                    foreach (SqlParametrosDapper parametro in parametros)
                    {
                        if (parametro.IsTypeTable)
                        {
                            dynamicParameters.Add(parametro.Name, ((DataTable)parametro.Value).AsTableValuedParameter());
                        }
                        else
                        {
                            if (parametro.Type == DbType.Decimal)
                            {
                                parametro.Precision = 28;
                                parametro.Scale = 4;                                
                            }
                            dynamicParameters.Add(parametro.Name, parametro.Value, dbType: parametro.Type,
                                direction: parametro.Direction, size: parametro.Size,
                                precision: parametro.Precision, scale: parametro.Scale);

                            if (parametro.Direction == ParameterDirection.Output)
                            {
                                numeroParametrosOut++;
                            }
                            else if (parametro.Direction == ParameterDirection.ReturnValue)
                            {
                                parametro.Value = -999;
                            }
                        }
                    }
                }
                return dynamicParameters;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public EjecutorDatos(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public IEnumerable<T> ExecuteDataSet<T>(ParametrosEjecucion parametrosEjecucion)
        {
            IEnumerable<T> listaRetorno;
            try
            {
                using (IDbConnection conexion = new SqlConnection(cadenaConexion))
                {
                    DynamicParameters parametros = new DynamicParameters();
                    parametros = AgregarParametrosConexion(parametrosEjecucion.DapperParametros);
                    listaRetorno = conexion.Query<T>(parametrosEjecucion.NombreProcedimiento, parametros, commandTimeout: timeOut, commandType: CommandType.StoredProcedure);
                }
            }
            catch (Exception)
            {
                throw;
            }
            return listaRetorno;
        }

        public Task<IEnumerable<T>> ExecuteDataSetAsync<T>(ParametrosEjecucion parametrosEjecucion)
        {
            throw new NotImplementedException();
        }

        public int ExecuteNonQuery(ParametrosEjecucion parametrosEjecucion)
        {
            throw new NotImplementedException();
        }

        public Task<int> ExecuteNonQueryAsync(ParametrosEjecucion parametrosEjecucion)
        {
            throw new NotImplementedException();
        }

        public T ExecuteScalar<T>(ParametrosEjecucion parametrosEjecucion)
        {
            throw new NotImplementedException();
        }

        public Task<T> ExecuteScalarAsync<T>(ParametrosEjecucion parametrosEjecucion)
        {
            throw new NotImplementedException();
        }
    }
}
