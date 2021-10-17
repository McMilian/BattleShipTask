using BattleShipTask.Models.Enums;
using Serilog;
using System.Collections.Generic;
using System.Linq;

namespace BattleShipTask.Models
{
    public class Ship
    {
        public int HealthPoints { get; private set; }
        public IList<Field> Parts { get; } = new List<Field>();

        public bool IsDestroyed => HealthPoints == 0;

        public Ship(IList<Field> parts)
        {
            Parts = parts;
            HealthPoints = Parts.Count;
        }

        public void DestroyShipPart(Position postion)
        {
            var part = Parts.Single(x => x.Position.Row == postion.Row && x.Position.Column == postion.Column);

            if (part is null || !part.IsShip)
            {
                Log.Warning("Shot didn't hit the ship");
                return;
            }

            Parts.Single(x => x.Position.Row == postion.Row && x.Position.Column == postion.Column).Content = Content.Wreck;
            HealthPoints--;
        }
    }
}
