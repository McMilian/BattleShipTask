using System.Text.RegularExpressions;

namespace BattleShipTask.Application.Interfaces
{
    public interface IUserCommandsService
    {
        int SetAndValidateSeed(string question);
        string SetAndValidateValue(string question, Regex regex);
    }
}
