using BattleShipTask.Application.Factories;
using BattleShipTask.Application.Interfaces;
using BattleShipTask.Application.Services;
using Microsoft.Extensions.DependencyInjection;

namespace BattleShipTask.Application.Configuration
{
    public static class ApplicationServiceCollectionExtensions
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services, ApplicationOptions options)
        {
            services.AddScoped<IDrawingService, DrawingService>()
                .AddScoped<IGameplayService, GameplayService>()
                .AddScoped<IUserCommandsService, UserCommandsService>()
                .AddScoped<IProbabilityGenerationService, ProbabilityGenerationService>();

            services.Configure<DrawingServiceOptions>(o =>
            {
                o.ShowOpponentsShips = options.ShowOpponentsShips;
            });

            return services;
        }

        public static IServiceCollection AddFactories(this IServiceCollection services, ApplicationOptions options)
        {
            services.AddScoped<IShipFactory, ShipFactory>()
                .AddScoped<IPlayersBoardFactory, PlayersBoardFactory>();

            services.Configure<PlayersBoardFactoryOptions>(o =>
            {
                o.ShipSettings = options.ShipsConfiguration.ShipSettings;
                o.MaxRetries = options.MaxNumberOfRandomTries;
            });

            return services;
        }
    }
}
