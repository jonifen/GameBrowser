using GameBrowser.Clients;
using GameBrowser.Clients.Games;
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
            services.AddScoped<IPingClient, PingClient>();
            services.AddScoped<ISocketProxy, SocketProxy>();
            services.AddScoped<IUdpServerClient, UdpServerClient>();

            ConfigureGameProtocolServices(services);
            ConfigureGameClientServices(services);
            ConfigureGameManagerServices(services);
            ConfigureResponseMapperServices(services);
        }

        public void ConfigureGameProtocolServices(IServiceCollection services)
        {
            services.AddScoped<IGamespyClient, GamespyClient>();
            services.AddScoped<IQuake3Client, Quake3Client>();
        }

        public void ConfigureGameManagerServices(IServiceCollection services)
        {
            services.AddScoped<IQuake3Manager, Quake3Manager>();
            services.AddScoped<IUnrealTournament99Manager, UnrealTournament99Manager>();
        }

        public void ConfigureGameClientServices(IServiceCollection services)
        {
            services.AddScoped<IQuake3GameClient, Quake3GameClient>();
            services.AddScoped<IUnrealTournament99GameClient, UnrealTournament99GameClient>();
        }

        public void ConfigureResponseMapperServices(IServiceCollection services)
        {
            services.AddScoped<Quake3.IStatusResponseMapper, Quake3.StatusResponseMapper>();
            services.AddScoped<UnrealTournament99.IInfoResponseMapper, UnrealTournament99.InfoResponseMapper>();
        }
    }
}
