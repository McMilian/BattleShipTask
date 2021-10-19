using System.Collections.Generic;
using System.Linq;
using BattleShipTask.Application.Models.Enums;
using Serilog;

namespace BattleShipTask.Application.Models
{
    public class Ship
    {
        public int HealthPoints { get; private set; }
        public IList<Field> Parts { get; }

        public bool IsDestroyed => HealthPoints == 0;

        public Ship(IEnumerable<Position> parts)
        {
            Parts = parts.Select(part => new Field(part, Content.Ship)).ToList();
            HealthPoints = Parts.Count;
        }

        public void DestroyShipPart(Position position)
        {
            var part = Parts.Single(x => x.Position.Row == position.Row && x.Position.Column == position.Column);

            if (!part.IsShip)
            {
                Log.Warning("Shot didn't hit the ship");
                return;
            }

            Parts.Single(x => x.Position.Row == position.Row && x.Position.Column == position.Column).Content = Content.Wreck;
            HealthPoints--;
        }
    }
}
