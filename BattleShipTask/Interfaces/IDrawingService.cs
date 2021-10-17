using BattleShipTask.Models;

namespace BattleShipTask.Interfaces
{
    public interface IDrawingService
    {
        public void DrawBoards(PlayersBoard playersBoard, PlayersBoard opponentsBoard);
    }
}
