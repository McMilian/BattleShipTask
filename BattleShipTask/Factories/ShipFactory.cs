using BattleShipTask.Interfaces;
using BattleShipTask.Models;
using BattleShipTask.Models.Enums;
using System.Collections.Generic;

namespace BattleShipTask.Factories
{
    public class ShipFactory : IShipFactory
    {
        public Ship Create(int size, Position startingPoint, bool isHorizontallyPlaced)
        {
            var parts = new List<Field>();
            for (int i = 0; i < size; i++)
            {
                if (isHorizontallyPlaced)
                {
                    parts.Add(new Field(new Position(startingPoint.Row, startingPoint.Column + i), Content.Ship));
                }
                else
                {
                    parts.Add(new Field(new Position(startingPoint.Row + i, startingPoint.Column), Content.Ship));
                }
            }

            return new Ship(parts);
        }
    }
}
