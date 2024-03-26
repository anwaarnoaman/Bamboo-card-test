using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
 

namespace Api.Installer
{
    public class HttpClientInstaller : IInstaller
    {
        public void InstallServices(IServiceCollection services, IConfiguration Configuration)
        {
            services.AddHttpClient();
        }
    }
}
