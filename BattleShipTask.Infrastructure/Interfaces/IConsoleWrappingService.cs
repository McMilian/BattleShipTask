namespace BattleShipTask.Infrastructure.Interfaces
{
    public interface IConsoleWrappingService
    {
        void WriteLine(string message);
        void WriteLine();
        string ReadLine();
    }
}
