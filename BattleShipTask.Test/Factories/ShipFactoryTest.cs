using BattleShipTask.Factories;
using BattleShipTask.Interfaces;
using BattleShipTask.Models;
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
            var size = 5;
            var startingRow = 3;
            var startingColumn = 5;
            var startingPoint = new Position(startingRow, startingColumn);
            var isHorizontallyPlaced = true;

            // Act
            var result = _sut.Create(size, startingPoint, isHorizontallyPlaced);

            // Assert
            result.HealthPoints.Should().Be(size);
            result.Parts.Should().HaveCount(size);
            result.Parts.Should().OnlyContain(field => field.Position.Row == startingRow);

            for (int i = startingColumn; i < size -1 ; i++)
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
            var isHorizontallyPlaced = false;

            // Act
            var result = _sut.Create(size, startingPoint, isHorizontallyPlaced);

            // Assert
            result.HealthPoints.Should().Be(size);
            result.Parts.Should().HaveCount(size);
            result.Parts.Should().OnlyContain(field => field.Position.Column == startingColumn);

            for (int i = startingColumn; i < size - 1; i++)
            {
                result.Parts.Should().Contain(field => field.Position.Row == i);
            }
        }
    }
}
