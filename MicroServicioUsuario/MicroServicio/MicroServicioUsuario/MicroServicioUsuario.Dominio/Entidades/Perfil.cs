using System;
using System.Collections.Generic;

#nullable disable

namespace MicroServicioUsuario.Dominio
{
    public partial class Perfil
    {
        public Perfil()
        {
            PerfilPantallas = new HashSet<PerfilPantalla>();
            UsuarioPerfils = new HashSet<UsuarioPerfil>();
        }

        public int IdPerfil { get; set; }
        public string Codigo { get; set; }
        public string Nombre { get; set; }
        public DateTime? FechaCreacion { get; set; }
        public bool? Activo { get; set; }
        public DateTime? FechaActualizacion { get; set; }

        public virtual ICollection<PerfilPantalla> PerfilPantallas { get; set; }
        public virtual ICollection<UsuarioPerfil> UsuarioPerfils { get; set; }
    }
}
