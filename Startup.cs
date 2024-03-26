
using Api.Installer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Linq;
using Microsoft.AspNetCore.Http.Connections;
using Api.Service.GlobalHandler;

namespace Api
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
            var installers = typeof(Startup).Assembly.ExportedTypes
                .Where(x => typeof(IInstaller)
                .IsAssignableFrom(x) && !x.IsInterface && !x.IsAbstract)
                .Select(Activator.CreateInstance).Cast<IInstaller>().ToList();

            installers.ForEach(installer => installer.InstallServices(services, Configuration));

            services.AddControllers();

            services.AddScoped<ResponseMiddleware>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
 
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseSwagger();
            app.UseSwaggerUI(
                c =>
                {
                    c.SwaggerEndpoint("/swagger/v1/swagger.json", "Api v1");
                    c.RoutePrefix = string.Empty; 
                }

                );

            app.UseMiddleware<ExceptionMiddleware>();
 
            //app.UseCors("AllowOrigin");
            app.UseCors("CorsPolicy");
            if (env.IsProduction())
            {
                app.UseHttpsRedirection();
            }
            app.UseRouting(); 
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
 
        }
    }
}
