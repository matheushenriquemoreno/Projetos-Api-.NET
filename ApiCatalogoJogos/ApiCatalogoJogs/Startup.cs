using ApiCatalogoJogs.Controllers.VersionamentoRotaV1;
using ApiCatalogoJogs.Repositories;
using ApiCatalogoJogs.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace ApiCatalogoJogs
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

            /*          Injetando a depencia 
                        
                        
            
                         Toda vez que a interface IjogoService estiver em um contrutor tem que dar uma instancia de JogoService.
             
             
             */

            services.AddScoped<IjogoService, JogoService>(); // primeiro a interface, depois a classe que implementa ela.
            services.AddScoped<IjogoRepository, JogoRepository>();


            services.AddTransient<IExemploTransient, ExemploCicloDeVida>();
            services.AddScoped<IExemploScoped, ExemploCicloDeVida>();
            services.AddSingleton<IExemploSingleton, ExemploCicloDeVida>(); 


            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "ApiCatalogoJogs", Version = "v1" });


                var basePath = AppDomain.CurrentDomain.BaseDirectory;
                var arquivoNome = typeof(Startup).GetTypeInfo().Assembly.GetName().Name + ".xml";
                c.IncludeXmlComments(Path.Combine(basePath, arquivoNome));
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment()) // se for ambiente de desenvolvimento entra no if 
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "ApiCatalogoJogs v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
