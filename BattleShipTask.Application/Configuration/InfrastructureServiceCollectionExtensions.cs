using BattleShipTask.Infrastructure.Interfaces;
using BattleShipTask.Infrastructure.Services;
using Microsoft.Extensions.DependencyInjection;

namespace BattleShipTask.Application.Configuration
{
    public static class InfrastructureServiceCollectionExtensions
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services)
        {
            services.AddScoped<IConsoleWrappingService, ConsoleWrappingService>();

            return services;
        }
    }
}
