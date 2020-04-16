using GameBrowser.Clients;
using GameBrowser.Managers;
using GameBrowser.Mappers;
using Microsoft.Extensions.DependencyInjection;

namespace GameBrowser
{
    public class IocSetup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddScoped<IQ3AManager, Q3AManager>();
            services.AddScoped<IPingClient, PingClient>();
            services.AddScoped<IQ3AServerClient, Q3AServerClient>();
            services.AddScoped<IQ3AServerResponseMapper, Q3AServerResponseMapper>();
        }
    }
}
