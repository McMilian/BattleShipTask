using System;
using BattleShipTask.Infrastructure.Interfaces;

namespace BattleShipTask.Infrastructure.Services
{
    public class ConsoleWrappingService : IConsoleWrappingService
    {
        public void WriteLine(string message)
        {
            Console.WriteLine(message);
        }

        public void WriteLine()
        {
            Console.WriteLine();
        }

        public string ReadLine()
        {
            return Console.ReadLine();
        }
    }
}
