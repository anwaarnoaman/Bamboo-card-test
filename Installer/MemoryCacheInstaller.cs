using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
 

namespace Api.Installer
{
    public class MemoryCacheInstaller : IInstaller
    {
        public void InstallServices(IServiceCollection services, IConfiguration Configuration)
        {
            services.AddMemoryCache();
        }
    }
}
