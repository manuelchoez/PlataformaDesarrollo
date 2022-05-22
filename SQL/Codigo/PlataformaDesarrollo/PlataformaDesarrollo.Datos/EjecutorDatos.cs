using Microsoft.Extensions.Configuration;
using PlataformaDesarrollo.Datos.Interfaces;
using PlataformaDesarrollo.Entidades;
using System;
using System.Collections.Generic;
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

        public IEnumerable<T> ExecuteDataSet<T>(ParametrosEjecucion parametrosEjecucion)
        {
            throw new NotImplementedException();
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
