using Dapper;
using Microsoft.Data.SqlClient;
using PlataformaDesarrollo.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlataformaDesarrollo.Datos
{
   internal class ProveedorCadenaConexion
    {
        public static Conexion ObtenerCadenaConexion(string modulo, string cadenaInfraestructura)
        {
            Conexion conexion = new Conexion();
                 
            string queryConexion = @"select IdConexion,Modulo,Fuente,Proveedor,Autenticacion,Usuario,Clave,NombreBaseDeDatos,Modelo from Conexion";
            using (SqlConnection connexion = new SqlConnection(cadenaInfraestructura))
            {
                List<Conexion> conexiones = connexion.Query<Conexion>(queryConexion).ToList();
                conexion = conexiones.Where(x => x.Modulo.Contains(modulo)).FirstOrDefault();
            }
            return conexion;
        }

        public static string ConstruirConfiguracionCadena(Conexion conexion)
        {
            SqlConnectionStringBuilder constructorcadena = new SqlConnectionStringBuilder();
            constructorcadena.DataSource = conexion.Fuente;
            constructorcadena.InitialCatalog = conexion.NombreBaseDeDatos;
            constructorcadena.IntegratedSecurity = (conexion.Autenticacion == ConstantesEjecutorDatos.WindowsAuthentication ? true : false);
            if (!constructorcadena.IntegratedSecurity)
            {
                constructorcadena.UserID = Encriptador.Desencriptar(conexion.Usuario);
                constructorcadena.Password = Encriptador.Desencriptar(conexion.Clave);
            }
            constructorcadena.MultipleActiveResultSets = true;
            return constructorcadena.ConnectionString;
        }
    }
}
