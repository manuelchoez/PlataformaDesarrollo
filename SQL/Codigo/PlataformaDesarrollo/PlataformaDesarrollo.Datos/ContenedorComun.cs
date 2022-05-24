using Microsoft.Extensions.DependencyInjection;
using PlataformaDesarrollo.Datos.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlataformaDesarrollo.Datos
{
    public static class ContenedorComun
    {
        public static void RegistrarServicios(IServiceCollection services)
        {
            services.AddScoped<IEjecutorDatos, EjecutorDatos>();
        }
    }
}
