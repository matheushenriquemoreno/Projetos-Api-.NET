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
using System.Threading.Tasks;
using Localica.Frotas.Infra.Singleton;
using Localica.Frotas.Domain;
using Localica.Frotas.Infra.Repository;
using Microsoft.EntityFrameworkCore;
using Localica.Frotas.Infra.Repository.Entiti;
using Localica.Frotas.Infra.Facede;

namespace Localiza.Frotas
{
    public class Startup
    {
        // Quando rodar a aplicação necessario trocar a url para /swagger/index.html

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();

            services.AddSwaggerGen(c =>
            {

                c.SwaggerDoc("v1", new OpenApiInfo  // configurando o xml para gerar a aplicação 
                {
                    Title = "Localiza.Frotas",
                    Description = "API - Frotas",
                    Version = "v1"
                });

                var apiPath = Path.Combine(AppContext.BaseDirectory, "Localiza.Frotas.xml");
                c.IncludeXmlComments(apiPath);
            });




            services.AddSingleton<SingletonContainer>(); // AddSingleton =  garante somete uma instancia enquanto estiver rodando a aplicação 

            services.AddTransient<IveiculosRepository, FrotaRepository>(); // possivel usar 2 repository 1 InmemoryRepository, outro FrotaRepository

            services.AddDbContext<FrotaContext>(opt => opt.UseInMemoryDatabase("frota"));

            services.AddTransient<IveiculosDetran, VeiculoDetranFacade>();

            services.Configure<DetranOptions>(Configuration.GetSection("DetranOptions"));

            services.AddHttpClient();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            { 
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "API Localiza.Frotas");  
            });

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
