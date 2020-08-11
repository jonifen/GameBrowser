using GameBrowser.Clients;
using GameBrowser.Clients.Protocols;
using GameBrowser.Managers;
using GameBrowser.Proxies;
using Microsoft.Extensions.DependencyInjection;
using Quake3 = GameBrowser.Mappers.Quake3;
using UnrealTournament99 = GameBrowser.Mappers.UnrealTournament99;

namespace GameBrowser
{
    public class IocSetup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddScoped<IQ3AManager, Q3AManager>();
            services.AddScoped<IPingClient, PingClient>();
            services.AddScoped<IUdpServerClient, UdpServerClient>();
            services.AddScoped<IQ3AServerClient, Q3AServerClient>();
            services.AddScoped<IGamespyClient, GamespyClient>();
            services.AddScoped<IUT99Manager, UT99Manager>();
            services.AddScoped<Quake3.IServerResponseMapper, Quake3.ServerResponseMapper>();
            services.AddScoped<UnrealTournament99.IInfoResponseMapper, UnrealTournament99.InfoResponseMapper>();

            services.AddScoped<ISocketProxy, SocketProxy>();
        }
    }
}
