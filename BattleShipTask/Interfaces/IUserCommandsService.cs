using System;
using System.Text.RegularExpressions;

namespace BattleShipTask.Interfaces
{
    public interface IUserCommandsService
    {
        int SetAndValidateValue(string question, Func<int, bool> validation);
        string SetAndValidateValue(string question, Regex regex);
    }
}
