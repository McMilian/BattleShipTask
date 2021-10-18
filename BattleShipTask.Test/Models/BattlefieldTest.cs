using BattleShipTask.Models;
using BattleShipTask.Test.Builders;
using FluentAssertions;
using System.Collections.Generic;
using Xunit;

namespace BattleShipTask.Test.Models
{
    public class BattlefieldTest
    {
        private readonly ShipBuilder _shipBuilder = new ShipBuilder();
        private readonly Battlefield _battlefield = new Battlefield(10);

        [Fact]
        public void It_returns_true_if_ship_fits()
        {
            // Arrange
            var shipParts = new List<Position> {
            new Position(4,4),
            new Position(4,5),
            new Position(4,6),
            new Position(4,7)
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
            var shipParts = new List<Position> {
            new Position(10,7),
            new Position(10,8),
            new Position(10,9),
            new Position(10,10),
            new Position(10,11)
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

            var shipParts = new List<Position> {
            waterPosition,
            new Position(6, 8),
            new Position(6, 9)
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
