using Microsoft.Extensions.DependencyInjection;
using PlataformaDesarrollo.Cache.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlataformaDesarrollo.Cache
{
    public class ContenedorComun
    {
        public static void RegistrarServiciosCache(IServiceCollection services)
        {
            services.AddScoped<IPlataformaCache, PlataformaCache>();
        }
    }
}
