using BattleShipTask.Interfaces;
using BattleShipTask.Models;
using BattleShipTask.Models.Enums;
using System;
using System.Collections.Generic;

namespace BattleShipTask.Factories
{
    public class PlayersBoardFactory : IPlayersBoardFactory
    {
        private readonly IShipFactory _shipFactory;
        private readonly IProbabilityGenerationService _probabilityGenerationService;
        public PlayersBoardFactory(IShipFactory shipFactory, IProbabilityGenerationService probabilityGenerationService)
        {
            _shipFactory = shipFactory;
            _probabilityGenerationService = probabilityGenerationService;
        }

        public PlayersBoard Create(int battlefieldSize, ShipsConfiguration shipsConfiguration, int seed)
        {
            var battlefield = new Battlefield(battlefieldSize);
            int retries = 0;
            var shipsList = new List<Ship>();
            var randomizer = seed + 10000;

            foreach (var shipConfig in shipsConfiguration.ShipSettings)
            {
                for (var i = 0; i < shipConfig.Count; i++)
                {
                    bool anotherDraw = true;

                    do
                    {
                        var isHorizontal = _probabilityGenerationService.CoinFlip(randomizer);
                        var startingPosition = _probabilityGenerationService.GetRandomStartingPosition(randomizer, 
                            isHorizontal, shipConfig.Size, battlefieldSize);

                        var ship = _shipFactory.Create(shipConfig.Size, startingPosition, isHorizontal);

                        var canShipBePlaced = battlefield.CheckIfShipFits(ship);

                        if (canShipBePlaced)
                        {
                            battlefield.InsertShip(ship);

                            if (isHorizontal)
                            {
                                SetFieldsAsWarterAroundHorizontalShip(battlefield, shipConfig, startingPosition.Row, startingPosition.Column);
                            }
                            else
                            {
                                SetFieldsAsWaterAroundVerticalShip(battlefield, shipConfig, startingPosition.Row, startingPosition.Column);
                            }

                            shipsList.Add(ship);

                            anotherDraw = false;
                        }
                        else
                        {
                            retries++;
                        }
                        randomizer += seed;
                    }
                    while (anotherDraw);
                }
            }

            Console.WriteLine($"There were {retries} retries in drawing"); //TODO do wywalenia 
            Console.WriteLine($"Finished at randomizer {randomizer}");

            return new PlayersBoard(shipsList);
        }

        private static void SetFieldsAsWarterAroundHorizontalShip(Battlefield battlefield, ShipSetting shipConfig, int row, int column)
        {
            // zaznacz jako woda pola wokół
            if (row - 1 > 0) //upper side
            {
                for (int i = 0; i < shipConfig.Size; i++)
                {
                    battlefield.GetFieldByPosition(row - 1, column + i).Content = Content.Water;
                }
            }

            if (row + 1 <= battlefield.Size) //lower side
            {
                for (int i = 0; i < shipConfig.Size; i++)
                {
                    battlefield.GetFieldByPosition(row + 1, column + i).Content = Content.Water;
                }
            }

            if (column - 1 > 0) //left side
            {
                battlefield.GetFieldByPosition(row, column - 1).Content = Content.Water;
            }

            if (column + shipConfig.Size <= battlefield.Size) // right side
            {
                battlefield.GetFieldByPosition(row, column + shipConfig.Size).Content = Content.Water;
            }

            //corners
            if (row - 1 > 0 && column - 1 > 0) // upper left
            {
                battlefield.GetFieldByPosition(row - 1, column - 1).Content = Content.Water;
            }

            if (row - 1 > 0 && column + shipConfig.Size <= battlefield.Size) // upper right
            {
                battlefield.GetFieldByPosition(row - 1, column + shipConfig.Size).Content = Content.Water;
            }

            if (row + 1 <= battlefield.Size && column - 1 > 0) // lower left
            {
                battlefield.GetFieldByPosition(row + 1, column - 1).Content = Content.Water;
            }

            if (row + 1 <= battlefield.Size && column + shipConfig.Size <= battlefield.Size) // lower right
            {
                battlefield.GetFieldByPosition(row + 1, column + shipConfig.Size).Content = Content.Water;
            }
        }

        private static void SetFieldsAsWaterAroundVerticalShip(Battlefield battlefield, ShipSetting shipConfig, int row, int column)
        {
            if (row - 1 > 0) //upper side
            {
                battlefield.GetFieldByPosition(row - 1, column).Content = Content.Water;
            }

            if (row + shipConfig.Size <= battlefield.Size) //lower side
            {
                battlefield.GetFieldByPosition(row + shipConfig.Size, column).Content = Content.Water;
            }

            if (column - 1 > 0) //left side
            {
                for (int i = 0; i < shipConfig.Size; i++)
                {
                    battlefield.GetFieldByPosition(row + i, column - 1).Content = Content.Water;
                }
            }

            if (column + 1 <= battlefield.Size) //right side
            {
                for (int i = 0; i < shipConfig.Size; i++)
                {
                    battlefield.GetFieldByPosition(row + i, column + 1).Content = Content.Water;
                }
            }

            //corners
            if (row - 1 > 0 && column - 1 > 0) // upper left
            {
                battlefield.GetFieldByPosition(row - 1, column - 1).Content = Content.Water;
            }

            if (row - 1 > 0 && column + 1 <= battlefield.Size) // upper right
            {
                battlefield.GetFieldByPosition(row - 1, column + 1).Content = Content.Water;
            }

            if (row + shipConfig.Size <= battlefield.Size && column - 1 > 0) // lower left
            {
                battlefield.GetFieldByPosition(row + shipConfig.Size, column - 1).Content = Content.Water;
            }

            if (row + shipConfig.Size <= battlefield.Size && column + 1 <= battlefield.Size) // lower right
            {
                battlefield.GetFieldByPosition(row + shipConfig.Size, column + 1).Content = Content.Water;
            }
        }
    }
}
