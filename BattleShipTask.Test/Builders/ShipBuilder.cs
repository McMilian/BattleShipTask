using BattleShipTask.Models;
using System.Collections.Generic;

namespace BattleShipTask.Test.Builders
{
    public class ShipBuilder
    {
        private IList<Position> _parts = new List<Position> {
            new Position(1,1),
            new Position(1,2),
            new Position(1,4),
            new Position(1,4)
        };

        public ShipBuilder WithParts(IList<Position> parts)
        {
            _parts = parts;
            return this; 
        }

        public Ship Build() {
            return new Ship(_parts);
        }
    }
}
