using BattleShipTask.Factories;
using BattleShipTask.Interfaces;
using BattleShipTask.Models;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace BattleShipTask.Test.Factories
{
    public class PlayersBoardFactoryTest
    {
        private readonly IPlayersBoardFactory _sut;
        private readonly IShipFactory _shipFactory;

        public PlayersBoardFactoryTest()
        {

        }

        [Fact]
        public void It_creates_board_with_ships()
        {
            // Arrange
            var shipsConfig = new ShipsConfiguration();
            

            // Act
            //_sut = new PlayersBoa


            // Assert
        }
    }
}
