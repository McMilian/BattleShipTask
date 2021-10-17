using System;
using System.IO;
using BattleShipTask.Configuration;
using BattleShipTask.Extensions;
using Microsoft.Extensions.DependencyInjection;
using BattleShipTask.Interfaces;
using Serilog;
using Microsoft.Extensions.Configuration;

namespace BattleShipTask
{
    public class Program
    {
        private static void Main()
        {
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetParent(AppContext.BaseDirectory).FullName)
                .AddJsonFile("appsettings.json", false)
                .Build();

            var options = configuration.GetSection("GameSettings").Get<ApplicationOptions>();

            var serviceProvider = new ServiceCollection()
                .AddApplicationServices()
                .AddFactories(options)
                .BuildServiceProvider();

            Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Information()
                .WriteTo.File("..\\..\\..\\logs\\log_.txt", rollingInterval: RollingInterval.Day)
                .CreateLogger();

            /* 1. Appsettings                                                      
             * 2. Więcej testów                                                                           
             * 4. logowanie błędów
             */

            var gameService = serviceProvider.GetService<IGameplayService>();

            gameService!.StartGame();
        }
    }
}
