using BattleShipTask.Models.Enums;
using System.Collections.Generic;
using System.Linq;

namespace BattleShipTask.Models
{
    public class PlayersBoard
    {
        public IEnumerable<Ship> Ships { get; }
        public IList<Position> MissedShotsReceived { get; } = new List<Position>();
        public IList<Position> MissedShotsExecuted { get; } = new List<Position>();

        public PlayersBoard(IEnumerable<Ship> ships)
        {
            Ships = ships;
        }

        public bool HasAnyUndestroyedShip()
        {
            return Ships.Any(ship => !ship.IsDestroyed);
        }

        public Content? ShootingOutcome(Position shot)
        {
            return Ships.SelectMany(ship => ship.Parts).SingleOrDefaultField(shot)?.Content;
        }

        public Ship GetDamagedShip(Position shot)
        {
            return Ships.First(ship => ship.Parts.SingleOrDefaultField(shot)?.Content == Content.Ship);
        }
    }
}
