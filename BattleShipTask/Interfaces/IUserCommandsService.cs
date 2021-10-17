using System.Text.RegularExpressions;

namespace BattleShipTask.Interfaces
{
    public interface IUserCommandsService
    {
        int SetAndValidateSeed(string question);
        string SetAndValidateValue(string question, Regex regex);
    }
}
