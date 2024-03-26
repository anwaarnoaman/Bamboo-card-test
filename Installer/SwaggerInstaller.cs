using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
 
namespace Api.Installer
{
    public class SwaggerInstaller : IInstaller
    {
        public void InstallServices(IServiceCollection services, IConfiguration Configuration)
        {
            services.AddSwaggerGen(s =>
            {
                s.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo
                {
                    Version = "v1",
                    Title = "Api",
                    Description = "Bamboo-card - Developer Coding Test",
                    
                }
                );

            });
        }
    }
}
