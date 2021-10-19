using BattleShipTask.Application.Models;

namespace BattleShipTask.Application.Interfaces
{
    public interface IDrawingService
    {
        public void DrawDashboard(PlayersBoard playersBoard, PlayersBoard opponentsBoard);
    }
}
