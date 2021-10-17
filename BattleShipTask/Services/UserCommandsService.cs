using BattleShipTask.Interfaces;
using System;
using System.Text.RegularExpressions;

namespace BattleShipTask.Services
{
    public class UserCommandsService : IUserCommandsService
    {
        private const int MinSeed = 0;
        private const int MaxSeed = 10000;
        public int SetAndValidateSeed(string question)
        {
            int insertedValue; 
            var isValueCorrect = false;

            do
            {
                Console.WriteLine();
                Console.WriteLine(question);
                
                if (int.TryParse(Console.ReadLine(), out insertedValue))
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
                Console.WriteLine();
                Console.WriteLine(question);

                insertedValue = Console.ReadLine() ?? string.Empty;

                isValueCorrect = validationRegex.IsMatch(insertedValue);
            }
            while (!isValueCorrect);

            return insertedValue;
        }

        private static bool ValidateSeed(int seed)
        {
            return seed > MinSeed && seed <= MaxSeed;
        }
    }
}
