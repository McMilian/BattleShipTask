using System.Text.RegularExpressions;
using BattleShipTask.Application.Interfaces;
using BattleShipTask.Infrastructure.Interfaces;

namespace BattleShipTask.Application.Services
{
    public class UserCommandsService : IUserCommandsService
    {
        private readonly IConsoleWrappingService _console;
        private const int MinSeed = 0;
        private const int MaxSeed = 10000;

        public UserCommandsService(IConsoleWrappingService console)
        {
            _console = console;
        }
        public int SetAndValidateSeed(string question)
        {
            int insertedValue; 
            var isValueCorrect = false;

            do
            {
                _console.WriteLine();
                _console.WriteLine(question);
                
                if (int.TryParse(_console.ReadLine(), out insertedValue))
                {
                    isValueCorrect = ValidateSeed(insertedValue);
                }
            }
            while (!isValueCorrect);

            return insertedValue;
        }

        public string SetAndValidateValue(string question, Regex validationRegex)
        {
            string insertedValue;
            bool isValueCorrect;
            do
            {
                _console.WriteLine();
                _console.WriteLine(question);

                insertedValue = _console.ReadLine() ?? string.Empty;

                isValueCorrect = validationRegex.IsMatch(insertedValue);
            }
            while (!isValueCorrect);

            return insertedValue;
        }

        private static bool ValidateSeed(int seed)
        {
            return seed is > MinSeed and <= MaxSeed;
        }
    }
}
