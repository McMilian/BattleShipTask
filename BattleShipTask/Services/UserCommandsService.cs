using BattleShipTask.Interfaces;
using System;
using System.Text.RegularExpressions;

namespace BattleShipTask.Services
{
    public class UserCommandsService : IUserCommandsService
    {
        public int SetAndValidateValue(string question, Func<int, bool> validation)
        {
            int insertedValue; 
            bool isValueCorrect = false;

            do
            {
                Console.WriteLine();
                Console.WriteLine(question);
                
                if (int.TryParse(Console.ReadLine(), out insertedValue))
                {
                    isValueCorrect = validation(insertedValue);
                }
            }
            while (!isValueCorrect);

            return insertedValue;
        }

        public string SetAndValidateValue(string question, Regex regex)
        {
            string insertedValue;
            bool isValueCorrect;
            do
            {
                Console.WriteLine();
                Console.WriteLine(question);

                insertedValue = Console.ReadLine();

                isValueCorrect = regex.IsMatch(insertedValue);
            }
            while (!isValueCorrect);

            return insertedValue;
        }
    }
}
