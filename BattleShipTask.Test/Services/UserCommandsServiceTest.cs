using BattleShipTask.Application.Constants;
using BattleShipTask.Application.Services;
using BattleShipTask.Infrastructure.Interfaces;
using FluentAssertions;
using NSubstitute;
using Xunit;

namespace BattleShipTask.Test.Services
{
    public class UserCommandsServiceTest
    {
        private readonly IConsoleWrappingService _console = Substitute.For<IConsoleWrappingService>();

        private UserCommandsService _sut;

        public UserCommandsServiceTest()
        {
            _sut = new UserCommandsService(_console);
        }

        [Fact]
        public void Set_and_validate_seed()
        {
            // Arrange
            var listOfInputs = new [] {"10001", "-1", "200"};
            _console.ReadLine().ReturnsForAnyArgs("wrong-input", listOfInputs);

            // Act
            var result = _sut.SetAndValidateSeed("test-question");

            // Assert
            result.Should().Be(200);
            _console.Received(listOfInputs.Length + 1).ReadLine();
        }

        [Fact]
        public void Set_and_validate_yes_regex()
        {
            // Arrange
            var listOfInputs = new[] { "10001", "-1", "!@#$%%^&*", "yes", "y" };
            _console.ReadLine().ReturnsForAnyArgs("wrong-input", listOfInputs);

            // Act
            var result = _sut.SetAndValidateValue("test-question", GameConstants.YesNoRegex);

            // Assert
            result.Should().Be("y");
            _console.Received(listOfInputs.Length + 1).ReadLine();
        }

        [Fact]
        public void Set_and_validate_no_regex()
        {
            // Arrange
            var listOfInputs = new[] { "23423", "-qwerty", "!@#$%%^&*", "nnnn", "n" };
            _console.ReadLine().ReturnsForAnyArgs("wrong-input", listOfInputs);

            // Act
            var result = _sut.SetAndValidateValue("test-question", GameConstants.YesNoRegex);

            // Assert
            result.Should().Be("n");
            _console.Received(listOfInputs.Length + 1).ReadLine();
        }

        [Fact]
        public void Set_and_validate_regex()
        {
            // Arrange
            var listOfInputs = new[] { "10001", "-1", "!@#$%%^&*", "yes", "y" };
            _console.ReadLine().ReturnsForAnyArgs("wrong-input", listOfInputs);

            // Act
            var result = _sut.SetAndValidateValue("test-question", GameConstants.YesNoRegex);

            // Assert
            result.Should().Be("y");
            _console.Received(listOfInputs.Length + 1).ReadLine();
        }

        [Fact]
        public void Set_and_validate_shot_coordinates()
        {
            // Arrange
            var listOfInputs = new[] { "10001", "Z1", "A11", "C-1", "A0001", "F5" };
            _console.ReadLine().ReturnsForAnyArgs("wrong-input", listOfInputs);

            // Act
            var result = _sut.SetAndValidateValue("test-question", GameConstants.ShotCoordinatesRegex);

            // Assert
            result.Should().Be("F5");
            _console.Received(listOfInputs.Length + 1).ReadLine();
        }
    }
}
