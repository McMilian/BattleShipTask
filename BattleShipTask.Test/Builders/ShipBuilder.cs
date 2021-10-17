﻿using BattleShipTask.Models;
using BattleShipTask.Models.Enums;
using System.Collections.Generic;

namespace BattleShipTask.Test.Builders
{
    public class ShipBuilder
    {
        private IList<Field> _parts = new List<Field> {
            new Field(new Position(1,1), Content.Ship),
            new Field(new Position(1,2), Content.Ship),
            new Field(new Position(1,4), Content.Ship),
            new Field(new Position(1,4), Content.Ship),
        };

        public ShipBuilder WithParts(IList<Field> parts)
        {
            _parts = parts;
            return this; 
        }

        public Ship Build() {
            return new Ship(_parts);
        }
    }
}
