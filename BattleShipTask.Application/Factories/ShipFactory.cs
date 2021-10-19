using System.Collections.Generic;
using BattleShipTask.Application.Interfaces;
using BattleShipTask.Application.Models;

namespace BattleShipTask.Application.Factories
{
    public class ShipFactory : IShipFactory
    {
        public Ship Create(int size, Position startingPoint, bool isHorizontallyPlaced)
        {
            var parts = new List<Position>();
            for (var i = 0; i < size; i++)
            {
                parts.Add(isHorizontallyPlaced
                    ? new Position(startingPoint.Row, startingPoint.Column + i)
                    : new Position(startingPoint.Row + i, startingPoint.Column));
            }

            return new Ship(parts);
        }
    }
}
