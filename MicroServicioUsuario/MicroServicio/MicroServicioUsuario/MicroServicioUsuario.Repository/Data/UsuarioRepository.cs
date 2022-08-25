using MicroServicioUsuario.Application.Constantes;
using MicroServicioUsuario.Dominio;
using MicroServicioUsuario.Dominio.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;
using PlataformaDesarrollo.Datos;
using PlataformaDesarrollo.Datos.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MicroServicioUsuario.Infraestructure.Data
{
    public class UsuarioRepository : IUsuarioRepository
    {        
        private readonly IEjecutorDatos _ejecutorDatos;

        public UsuarioRepository(IEjecutorDatos ejecutorDatos)
        {            
            _ejecutorDatos = ejecutorDatos;
        }

        public async Task<Usuario> ObtenerUsuario(Usuario usuario)
        {
            _ejecutorDatos.Modulo = Constantes.ModuloSeguridad;
            _ejecutorDatos.CadenaConexion = Constantes.CadenaConexionSeguridad;
            
            ParametrosEjecucion parametrosEjecucion = new ParametrosEjecucion
            {
                NombreProcedimiento = Constantes.pConsultaUsuario,
                DapperParametros = new[]{
                          
                            new SqlParametrosDapper("@Username",System.Data.DbType.String, 20,usuario.Username),
                            new SqlParametrosDapper("@Contrasenia",System.Data.DbType.String, 20, usuario.Contrasenia)                           
                }
            };
            IEnumerable<Usuario> resultado = await _ejecutorDatos.ExecuteDataSetAsync<Usuario>(parametrosEjecucion) ;
            return  resultado.First();
        }
    }
}
