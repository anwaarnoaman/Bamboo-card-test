
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
 

namespace Api.Installer
{
    public class SettingsInstaller : IInstaller
    {
        public void InstallServices(IServiceCollection services, IConfiguration Configuration)
        {
            services.Configure<ApiUrls>(Configuration.GetSection("ApiUrls"));
        }
    }
}
