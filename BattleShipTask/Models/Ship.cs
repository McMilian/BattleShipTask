using BattleShipTask.Models.Enums;
using Serilog;
using System.Collections.Generic;
using System.Linq;

namespace BattleShipTask.Models
{
    public class Ship
    {
        public int HealthPoints { get; private set; }
        public IList<Field> Parts { get; }

        public bool IsDestroyed => HealthPoints == 0;

        public Ship(IList<Field> parts)
        {
            Parts = parts;
            HealthPoints = Parts.Count;
        }

        public void DestroyShipPart(Position position)
        {
            var part = Parts.Single(x => x.Position.Row == position.Row && x.Position.Column == position.Column);

            if (part is null || !part.IsShip)
            {
                Log.Warning("Shot didn't hit the ship");
                return;
            }

            Parts.Single(x => x.Position.Row == position.Row && x.Position.Column == position.Column).Content = Content.Wreck;
            HealthPoints--;
        }
    }
}
