using System;
using System.Collections.Generic;

#nullable disable

namespace MicroServicioUsuario.Dominio
{
    public partial class PerfilPantalla
    {
        public int IdPerfilPantalla { get; set; }
        public int? IdPerfil { get; set; }
        public int? IdPantalla { get; set; }
        public DateTime? FechaCreacion { get; set; }
        public bool? Activo { get; set; }
        public DateTime? FechaActualizacion { get; set; }

        public virtual Pantalla IdPantallaNavigation { get; set; }
        public virtual Perfil IdPerfilNavigation { get; set; }
    }
}
