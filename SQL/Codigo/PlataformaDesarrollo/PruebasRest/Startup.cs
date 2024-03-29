using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using PlataformaDesarrollo.Datos;
using PlataformaDesarrollo.Cache;
using PruebasRest.Data;
using PruebasRest.Interfaces;
using Serilog;
using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PruebasRest
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            PlataformaDesarrollo.Datos.ContenedorComun.RegistrarServicios(services);
            PlataformaDesarrollo.Cache.ContenedorComun.RegistrarServiciosCache(services);
            services.AddSingleton(Log.Logger);
            services.AddCors();
            services.AddControllers();
            services.AddScoped<ICliente, ClienteRepository>();
            services.AddScoped<ICredito, CreditoRepository>();
            ConfigurationOptions configurationOptions = new ConfigurationOptions
            {
                EndPoints = { Configuration.GetValue<string>("RedisConnection")},
                User= "default",
                Password= "redispw"
            };

            services.AddSingleton<IConnectionMultiplexer>(_ => ConnectionMultiplexer.Connect(configurationOptions));
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "PruebasRest", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "PruebasRest v1"));
            }

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
