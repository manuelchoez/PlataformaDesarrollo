using System;
using System.Collections.Generic;

#nullable disable

namespace MicroServicioUsuario.Dominio
{
    public partial class UsuarioPerfil
    {
        public int IdUsuarioPerfil { get; set; }
        public int? IdUsuario { get; set; }
        public int? IdPerfil { get; set; }
        public DateTime? FechaCreacion { get; set; }
        public bool? Activo { get; set; }
        public DateTime? FechaActualizacion { get; set; }

        public virtual Perfil IdPerfilNavigation { get; set; }
        public virtual Usuario IdUsuarioNavigation { get; set; }
    }
}
