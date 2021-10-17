using BattleShipTask.Models;
using BattleShipTask.Models.Enums;
using BattleShipTask.Test.Builders;
using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace BattleShipTask.Test.Models
{
    public class BattlefieldTest
    {
        private ShipBuilder _shipBuilder = new ShipBuilder();
        private Battlefield _battlefield = new Battlefield(10);

        [Fact]
        public void It_returns_true_if_ship_fits()
        {
            // Arrange
            var shipParts = new List<Field> {
            new Field(new Position(4,4), FieldValue.Ship),
            new Field(new Position(4,5), FieldValue.Ship),
            new Field(new Position(4,6), FieldValue.Ship),
            new Field(new Position(4,7), FieldValue.Ship)
            };

            var ship = _shipBuilder.WithParts(shipParts).Build();

            // Act

            var result = _battlefield.CheckIfShipFits(ship);

            // Assert

            result.Should().BeTrue();
        }

        [Fact]
        public void It_returns_false_if_ship_is_out_of_battlefield()
        {
            // Arrange
            var shipParts = new List<Field> {
            new Field(new Position(10,7), FieldValue.Ship),
            new Field(new Position(10,8), FieldValue.Ship),
            new Field(new Position(10,9), FieldValue.Ship),
            new Field(new Position(10,10), FieldValue.Ship),
            new Field(new Position(10,11), FieldValue.Ship)
            };

            var ship = _shipBuilder.WithParts(shipParts).Build();

            // Act

            var result = _battlefield.CheckIfShipFits(ship);

            // Assert

            result.Should().BeFalse();
        }

        [Fact]
        public void It_returns_false_if_field_is_used()
        {
            // Arrange
            var waterPosition = new Position(6, 7);

            var water = new List<Position> { waterPosition };

            var shipParts = new List<Field> {
            new Field(waterPosition, FieldValue.Ship),
            new Field(new Position(6, 8), FieldValue.Ship),
            new Field(new Position(6, 9), FieldValue.Ship)
            };

            var ship = _shipBuilder.WithParts(shipParts).Build();
            _battlefield.InsertWater(water);

            // Act

            var result = _battlefield.CheckIfShipFits(ship);

            // Assert

            result.Should().BeFalse();
        }

    }
}
