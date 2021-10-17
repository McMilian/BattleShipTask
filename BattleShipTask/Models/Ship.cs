using BattleShipTask.Models.Enums;
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
            //Tu powinien być exception handling jak nie znajdzie części
            Parts.Single(x => x.Position.Row == postion.Row && x.Position.Column == postion.Column).Content = FieldValue.Wreck;
            HealthPoints--;
        }
    }
}
