using BattleShipTask.Models.Enums;
using System.Collections.Generic;
using System.Linq;

namespace BattleShipTask.Models
{
    public class Battlefield
    {
        public int Size { get; }
        public IEnumerable<Field> Fields { get; }


        public Battlefield(int size)
        {
            Size = size;

            var fields = new List<Field>();

            for (int i = 1; i <= size; i++)
            {
                for (int j = 1; j <= size; j++)
                {
                    fields.Add(new Field(new Position(i, j)));
                }
            }

            Fields = fields;
        }

        public bool CheckIfShipFits(Ship ship)
        {
            var fields = new List<Field>();

            foreach (var shipPart in ship.Parts)
            {
                var areaToPutShip = Fields.SingleOrDefault(field => field.Position.Row == shipPart.Position.Row &&
                 field.Position.Column == shipPart.Position.Column);

                if(areaToPutShip != null)
                {
                    fields.Add(areaToPutShip);
                }
            }

            return fields.All(field => field.Content == null) && fields.Count == ship.Size;
        }

        public void InsertShip(Ship ship)
        {
            foreach (var shipPart in ship.Parts)
            {
                Fields.Single(field => field.Position.Row == shipPart.Position.Row &&
                 field.Position.Column == shipPart.Position.Column).Content = shipPart.Content;
            }
        }

        public void InsertWater(IEnumerable<Position> shots)
        {
            foreach (var shot in shots)
            {
                Fields.Single(field => field.Position.Row == shot.Row &&
                 field.Position.Column == shot.Column).Content = FieldValue.Water;
            }
        }
    }
}
