using BattleShipTask.Models;
using System.Collections.Generic;

namespace BattleShipTask.Interfaces
{
    public interface IDrawingService
    {
        //public void DrawBattlefield(Battlefield battlefield, bool showShips);
        //public void DrawBattlefieldUsingShips(IEnumerable<Ship> shipsList, IEnumerable<Position> missedShots, bool showShips);
        public void DrawBothBattlefieldsUsingShips(PlayersBoard playersBoard, PlayersBoard opponentsBoard);
    }
}
