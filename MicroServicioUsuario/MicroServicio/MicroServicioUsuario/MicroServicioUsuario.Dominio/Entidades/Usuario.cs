using System;
using System.Collections.Generic;

#nullable disable

namespace MicroServicioUsuario.Dominio
{
    public partial class Usuario
    {
        public Usuario()
        {
            UsuarioPerfils = new HashSet<UsuarioPerfil>();
        }

        public int IdUsuario { get; set; }
        public string Username { get; set; }
        public string Contrasenia { get; set; }
        public DateTime? FechaCreacion { get; set; }
        public bool? Activo { get; set; }
        public DateTime? FechaActualizacion { get; set; }

        public virtual ICollection<UsuarioPerfil> UsuarioPerfils { get; set; }
    }
}
