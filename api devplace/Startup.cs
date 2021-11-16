using DevPlace.Blog.API.Repository;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace DevPlace.Blog.API
{
    public class Startup
    {
        private const string ConnectionStringKey = "BlogConnection";

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddDbContext<DbContextApi>(options =>
            {
                // Lee el connection string desde el archivo appsettings.com
                // A partir de ahora, será reconfigurable sin necesidad de recompilar código.
                options.UseSqlServer(Configuration.GetConnectionString(ConnectionStringKey));
            });

            // Agregar el servicio que genera la especificación de la API.
            // Luego, debajo en la función Configure() se agrega SwaggerUI()
            // Para generar la interfaz grafica que permite probar la API.
            services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new OpenApiInfo { Title = "Blog API", Version = "v1" });
            });

            // Registrar todos los validadores en la carpeta /Domain/Validation
            services.AddControllers().AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<Startup>());
            
            // Agregar Automapper, para poder mapear/copiar los valores desde
            // Una instancia de un objeto (clase A) a otra instancia de objecto (clase B)
            // Por ejemplo: Desde un DTO a una clase del modelo
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>

                {
                    endpoints.MapControllers();
                });

            // Agregar Swagger UI para poder navegar a la ruta y ver los endpoints.
            app.UseSwagger();
            app.UseSwaggerUI(options =>
            {
                options.RoutePrefix = "swagger";
                options.SwaggerEndpoint(url: "/swagger/v1/swagger.json", "Blog.API");
            });
        }
    }
}
