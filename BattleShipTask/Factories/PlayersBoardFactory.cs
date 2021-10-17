using BattleShipTask.Interfaces;
using BattleShipTask.Models;
using System;
using System.Collections.Generic;
using BattleShipTask.Configuration;
using Microsoft.Extensions.Options;

namespace BattleShipTask.Factories
{
    public class PlayersBoardFactory : IPlayersBoardFactory
    {
        private readonly IShipFactory _shipFactory;
        private readonly IProbabilityGenerationService _probabilityGenerationService;
        private readonly PlayersBoardFactoryOptions _options;
        public PlayersBoardFactory(IShipFactory shipFactory, IProbabilityGenerationService probabilityGenerationService,
            IOptions<PlayersBoardFactoryOptions> options)
        {
            _shipFactory = shipFactory;
            _probabilityGenerationService = probabilityGenerationService;
            _options = options.Value;
        }

        public PlayersBoard Create(int battlefieldSize, int seed)
        {
            var battlefield = new Battlefield(battlefieldSize);
            int retries = 0;
            var shipsList = new List<Ship>();
            var randomizer = seed + 10000;

            foreach (var shipConfig in _options.ShipSettings)
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

            var waterFields = new List<Position>();

            if (row - 1 > 0) //upper side
            {
                for (int i = 0; i < shipConfig.Size; i++)
                {
                    waterFields.Add(new Position(row - 1, column + i));
                }
            }

            if (row + 1 <= battlefield.Size) //lower side
            {
                for (int i = 0; i < shipConfig.Size; i++)
                {
                    waterFields.Add(new Position(row + 1, column + i));
                }
            }

            if (column - 1 > 0) //left side
            {
                waterFields.Add(new Position(row, column - 1));
            }

            if (column + shipConfig.Size <= battlefield.Size) // right side
            {
                waterFields.Add(new Position(row, column + shipConfig.Size));
            }

            //corners
            if (row - 1 > 0 && column - 1 > 0) // upper left
            {
                waterFields.Add(new Position(row - 1, column - 1));
            }

            if (row - 1 > 0 && column + shipConfig.Size <= battlefield.Size) // upper right
            {
                waterFields.Add(new Position(row - 1, column + shipConfig.Size));
            }

            if (row + 1 <= battlefield.Size && column - 1 > 0) // lower left
            {
                waterFields.Add(new Position(row + 1, column - 1));
            }

            if (row + 1 <= battlefield.Size && column + shipConfig.Size <= battlefield.Size) // lower right
            {
                waterFields.Add(new Position(row + 1, column + shipConfig.Size));
            }

            battlefield.InsertWater(waterFields);
        }

        private static void SetFieldsAsWaterAroundVerticalShip(Battlefield battlefield, ShipSetting shipConfig, int row, int column)
        {
            var waterFields = new List<Position>();
            
            if (row - 1 > 0) //upper side
            {
                waterFields.Add(new Position(row - 1, column));
            }

            if (row + shipConfig.Size <= battlefield.Size) //lower side
            {
                waterFields.Add(new Position(row + shipConfig.Size, column));
            }

            if (column - 1 > 0) //left side
            {
                for (int i = 0; i < shipConfig.Size; i++)
                {
                    waterFields.Add(new Position(row + i, column - 1));
                }
            }

            if (column + 1 <= battlefield.Size) //right side
            {
                for (int i = 0; i < shipConfig.Size; i++)
                {
                    waterFields.Add(new Position(row + i, column + 1));
                }
            }

            //corners
            if (row - 1 > 0 && column - 1 > 0) // upper left
            {
                waterFields.Add(new Position(row - 1, column - 1));
            }

            if (row - 1 > 0 && column + 1 <= battlefield.Size) // upper right
            {
                waterFields.Add(new Position(row - 1, column + 1));
            }

            if (row + shipConfig.Size <= battlefield.Size && column - 1 > 0) // lower left
            {
                waterFields.Add(new Position(row + shipConfig.Size, column - 1));
            }

            if (row + shipConfig.Size <= battlefield.Size && column + 1 <= battlefield.Size) // lower right
            {
                waterFields.Add(new Position(row + shipConfig.Size, column + 1));
            }

            battlefield.InsertWater(waterFields);
        }
    }
}
