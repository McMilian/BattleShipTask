using System.Collections.Generic;
using System.Linq;

namespace BattleShipTask.Models
{
    public class PlayersBoard
    {
        //Player's number should be added?
        public string PlayersName { get; }
        public IEnumerable<Ship> Ships { get; }
        public IList<Position> MissedShotsReceived { get; } = new List<Position>();
        public IList<Position> MissedShotsExecuted { get; } = new List<Position>();

        public PlayersBoard(string name, IEnumerable<Ship> ships)
        {
            PlayersName = name;
            Ships = ships;
        }

        public bool HasAnyUndestroyedShip()
        {
            return Ships.Any(ship => !ship.IsDestroyed);
        }
    }
}
