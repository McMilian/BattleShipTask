using BattleShipTask.Models.Enums;
using System.Collections.Generic;
using System.Linq;

namespace BattleShipTask.Models
{
    public class Ship
    {
        public int Size { get; }
        public int HealthPoints { get; set; }
        public IList<Field> Parts { get; } = new List<Field>();
        public bool IsHorizontallyPlaced { get; }

        public bool IsDestroyed => HealthPoints == 0;

        public Ship(int size, IList<Field> parts, bool isHorizontallyPlaced)
        {
            Size = size; //to raczej nie jest tu potrzebne po utworzeniu
            HealthPoints = size;
            Parts = parts;
            IsHorizontallyPlaced = isHorizontallyPlaced; //to raczej nie jest tu potrzebne
        }

        public Ship(int size, Position startingPoint, bool isHorizontallyPlaced) // to do factory.
        {
            Size = size;
            IsHorizontallyPlaced = isHorizontallyPlaced;
            HealthPoints = size;
 
            for (int i = 0; i < Size; i++)
            {
                if (isHorizontallyPlaced)
                {
                    Parts.Add(new Field(new Position(startingPoint.Row, startingPoint.Column + i), FieldValue.Ship));
                }
                else
                {
                    Parts.Add(new Field(new Position(startingPoint.Row + i, startingPoint.Column), FieldValue.Ship));
                }

            }
        }

        public void DestroyShipPart(Position postion)
        {

            //Tu powinien być exception handling jak nie znajdzie części
            Parts.Single(x => x.Position.Row == postion.Row && x.Position.Column == postion.Column).Content = FieldValue.Wreck;
            HealthPoints--;
        }
    }
}
