using BattleShipTask.Test.Builders;
using FluentAssertions;
using System.Collections.Generic;
using System.Linq;
using BattleShipTask.Application.Models;
using BattleShipTask.Application.Models.Enums;
using Xunit;

namespace BattleShipTask.Test.Models
{
    public class ShipTest
    {
        private readonly ShipBuilder _shipBuilder = new();

        [Fact]
        public void It_destroys_ship_part()
        {
            // Arrange
            var shot = new Position(1, 1);
            var shipParts = new List<Field> {
            new Field(shot, Content.Ship),
            new Field(new Position(1,2), Content.Ship),
            new Field(new Position(1,4), Content.Ship),
            new Field(new Position(1,4), Content.Ship)
            };

            var ship = _shipBuilder.Build();

            // Act
            ship.DestroyShipPart(shot);

            // Assert
            ship.HealthPoints.Should().Be(shipParts.Count - 1);
            ship.Parts.Single(field => field.Position.Row == shot.Row && field.Position.Column == shot.Column)
                .Content.Should().Be(Content.Wreck);
        }
    }
}
