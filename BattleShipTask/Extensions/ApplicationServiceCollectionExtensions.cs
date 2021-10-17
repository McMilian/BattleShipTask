using System.Security.Cryptography.X509Certificates;
using BattleShipTask.Configuration;
using BattleShipTask.Factories;
using BattleShipTask.Interfaces;
using BattleShipTask.Services;
using Microsoft.Extensions.DependencyInjection;

namespace BattleShipTask.Extensions
{
    public static class ApplicationServiceCollectionExtensions
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddScoped<IDrawingService, DrawingService>()
                .AddScoped<IGameplayService, GameplayService>()
                .AddScoped<IUserCommandsService, UserCommandsService>()
                .AddScoped<IProbabilityGenerationService, ProbabilityGenerationService>();

            return services;
        }

        public static IServiceCollection AddFactories(this IServiceCollection services, ApplicationOptions options)
        {
            services.AddScoped<IShipFactory, ShipFactory>()
                .AddScoped<IPlayersBoardFactory, PlayersBoardFactory>();

            services.Configure<PlayersBoardFactoryOptions>(o =>
            {
                o.ShipSettings = options.ShipsConfiguration.ShipSettings;
            });

            return services;
        }
    }
}
