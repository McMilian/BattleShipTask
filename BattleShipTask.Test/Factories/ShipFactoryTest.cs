using BattleShipTask.Application.Factories;
using BattleShipTask.Application.Interfaces;
using BattleShipTask.Application.Models;
using FluentAssertions;
using Xunit;

namespace BattleShipTask.Test.Factories
{
    public class ShipFactoryTest
    {
        private readonly IShipFactory _sut = new ShipFactory();

        [Fact]
        public void Create_horizontally_placed_ship()
        {
            // Arrange
            const int size = 5;
            const int startingRow = 3;
            const int startingColumn = 5;
            var startingPoint = new Position(startingRow, startingColumn);

            // Act
            var result = _sut.Create(size, startingPoint, true);

            // Assert
            result.HealthPoints.Should().Be(size);
            result.Parts.Should().HaveCount(size);
            result.Parts.Should().OnlyContain(field => field.Position.Row == startingRow);

            for (var i = startingColumn; i < startingColumn + size - 1 ; i++)
            {
                result.Parts.Should().Contain(field => field.Position.Column == i);
            }
        }

        [Fact]
        public void Create_vertically_placed_ship()
        {
            // Arrange
            var size = 4;
            var startingRow = 2;
            var startingColumn = 8;
            var startingPoint = new Position(startingRow, startingColumn);

            // Act
            var result = _sut.Create(size, startingPoint, false);

            // Assert
            result.HealthPoints.Should().Be(size);
            result.Parts.Should().HaveCount(size);
            result.Parts.Should().OnlyContain(field => field.Position.Column == startingColumn);

            for (int i = startingColumn; i < startingRow + size - 1; i++)
            {
                result.Parts.Should().Contain(field => field.Position.Row == i);
            }
        }
    }
}
