﻿using System;
using System.IO;
using BattleShipTask.Configuration;
using Microsoft.Extensions.DependencyInjection;
using BattleShipTask.Interfaces;
using Serilog;
using Microsoft.Extensions.Configuration;
using Serilog.Exceptions;
using BattleShipTask.Exceptions;
using BattleShipTask.Constants;

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
                .Enrich.WithExceptionDetails()
                .WriteTo.File("..\\..\\..\\logs\\log_.txt", rollingInterval: RollingInterval.Day)
                .CreateLogger();

            try
            {
                var gameService = serviceProvider.GetService<IGameplayService>();
                gameService!.StartGame();
            }
            catch (BattleshipApplicationException ex)
            {
                Console.WriteLine(GameConstants.ApplicationException);
                Console.WriteLine(ex.Message);

                Log.Error("ErrorType: {0} \r\n ErrorMessage: {1} \r\n StackTrace: {2}", ex.Type, 
                    ex.Message, ex.StackTrace);
            }
            catch (Exception ex)
            {
                Console.WriteLine(GameConstants.ApplicationException);

                Log.Error("ErrorMessage: {0} \r\n StackTrace: {1}", ex.Message, 
                    ex.StackTrace);
            }
        }
    }
}
