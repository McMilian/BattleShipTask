using BattleShipTask.Interfaces;
using BattleShipTask.Models;
using BattleShipTask.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BattleShipTask.Services
{
    public class ShipsLocationGenerationService : IShipsLocationGenerationService
    {

        //TO jest do usunięcia
        public Battlefield GenerateBattlefieldWithShips(int size, ShipsConfiguration shipsConfiguration)
        {
            var battlefield = new Battlefield(size);
            int retries = 0;

            foreach (var shipConfig in shipsConfiguration.ShipSettings)
            {
                for (var i = 0; i < shipConfig.Count; i++)
                {
                    bool anotherDraw = true;

                    do
                    {
                        var isHorizontal = new Random().Next(1, 100) <= 50; // move to probability generator as CoinFlip

                        Position startingPostion;

                        if (isHorizontal)
                        {
                            startingPostion = new Position(new Random().Next(1, size + 1),
                                    new Random().Next(1, size - shipConfig.Size + 2));
                        }
                        else
                        {
                            startingPostion = new Position(new Random().Next(1, size - shipConfig.Size + 2),
                                new Random().Next(1, size + 1));
                        }

                        var ship = new Ship(shipConfig.Size, startingPostion, isHorizontal);

                        var canShipBePlaced = battlefield.CheckIfShipFits(ship);

                        if (canShipBePlaced)
                        {
                            battlefield.InsertShip(ship);

                            if (isHorizontal)
                            {
                                SetFieldsAsWarterAroundHorizontalShip(battlefield, shipConfig, startingPostion.Row, startingPostion.Column);
                            }
                            else
                            {
                                SetFieldsAsWaterAroundVerticalShip(battlefield, shipConfig, startingPostion.Row, startingPostion.Column);
                            }

                            anotherDraw = false;
                        }
                        else
                        {
                            retries++;
                        }
                    }
                    while (anotherDraw);
                }
            }

            Console.WriteLine($"There were {retries} retries in drawing");
            return battlefield;
        }


        public IEnumerable<Ship> GenerateShipsLocation(int battlefieldSize, ShipsConfiguration shipsConfiguration)
        {
            var battlefield = new Battlefield(battlefieldSize);
            int retries = 0;
            var shipsList = new List<Ship>();

            foreach (var shipConfig in shipsConfiguration.ShipSettings)
            {
                for (var i = 0; i < shipConfig.Count; i++)
                {
                    bool anotherDraw = true;

                    do
                    {
                        var isHorizontal = new Random().Next(1, 100) <= 50; // move to probability generator as CoinFlip

                        Position startingPostion;

                        if (isHorizontal)
                        {
                            startingPostion = new Position(new Random().Next(1, battlefieldSize + 1),
                                    new Random().Next(1, battlefieldSize - shipConfig.Size + 2));
                        }
                        else
                        {
                            startingPostion = new Position(new Random().Next(1, battlefieldSize - shipConfig.Size + 2),
                                new Random().Next(1, battlefieldSize + 1));
                        }

                        var ship = new Ship(shipConfig.Size, startingPostion, isHorizontal);

                        var canShipBePlaced = battlefield.CheckIfShipFits(ship);

                        if (canShipBePlaced)
                        {
                            battlefield.InsertShip(ship);

                            if (isHorizontal)
                            {
                                SetFieldsAsWarterAroundHorizontalShip(battlefield, shipConfig, startingPostion.Row, startingPostion.Column);
                            }
                            else
                            {
                                SetFieldsAsWaterAroundVerticalShip(battlefield, shipConfig, startingPostion.Row, startingPostion.Column);
                            }

                            shipsList.Add(ship);

                            anotherDraw = false;
                        }
                        else
                        {
                            retries++;
                        }
                    }
                    while (anotherDraw);
                }
            }

            Console.WriteLine($"There were {retries} retries in drawing");

            return shipsList;
        }

        public IEnumerable<Ship> GenerateShipsLocationWithSeed(int battlefieldSize, ShipsConfiguration shipsConfiguration, int seed)
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
                        var isHorizontal = new Random(randomizer + 13).Next(1, 100) <= 50; // move to probability generator as CoinFlip

                        Position startingPostion;

                        if (isHorizontal)
                        {
                            startingPostion = new Position(new Random(randomizer * 2 + 67).Next(1, battlefieldSize + 1),
                                    new Random(randomizer * 3 + 17).Next(1, battlefieldSize - shipConfig.Size + 2));
                        }
                        else
                        {
                            startingPostion = new Position(new Random(randomizer * 4 + 99).Next(1, battlefieldSize - shipConfig.Size + 2),
                                new Random(randomizer * 5 + 54).Next(1, battlefieldSize + 1));
                        }

                        var ship = new Ship(shipConfig.Size, startingPostion, isHorizontal);

                        var canShipBePlaced = battlefield.CheckIfShipFits(ship);

                        if (canShipBePlaced)
                        {
                            battlefield.InsertShip(ship);

                            if (isHorizontal)
                            {
                                SetFieldsAsWarterAroundHorizontalShip(battlefield, shipConfig, startingPostion.Row, startingPostion.Column);
                            }
                            else
                            {
                                SetFieldsAsWaterAroundVerticalShip(battlefield, shipConfig, startingPostion.Row, startingPostion.Column);
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

            Console.WriteLine($"There were {retries} retries in drawing");

            return shipsList;
        }

        private static void SetFieldsAsWarterAroundHorizontalShip(Battlefield battlefield, ShipSetting shipConfig, int row, int column)
        {
            // zaznacz jako woda pola wokół
            if (row - 1 > 0) //upper side
            {
                for (int i = 0; i < shipConfig.Size; i++)
                {
                    battlefield.GetFieldByPosition(row - 1, column + i).Content = FieldValue.Water;
                }
            }

            if (row + 1 <= battlefield.Size) //lower side
            {
                for (int i = 0; i < shipConfig.Size; i++)
                {
                    battlefield.GetFieldByPosition(row + 1, column + i).Content = FieldValue.Water;
                }
            }

            if (column - 1 > 0) //left side
            {
                battlefield.GetFieldByPosition(row, column - 1).Content = FieldValue.Water;
            }

            if (column + shipConfig.Size <= battlefield.Size) // right side
            {
                battlefield.GetFieldByPosition(row, column + shipConfig.Size).Content = FieldValue.Water;
            }

            //corners
            if (row - 1 > 0 && column - 1 > 0) // upper left
            {
                battlefield.GetFieldByPosition(row - 1, column - 1).Content = FieldValue.Water;
            }

            if (row - 1 > 0 && column + shipConfig.Size <= battlefield.Size) // upper right
            {
                battlefield.GetFieldByPosition(row - 1, column + shipConfig.Size).Content = FieldValue.Water;
            }

            if (row + 1 <= battlefield.Size && column - 1 > 0) // lower left
            {
                battlefield.GetFieldByPosition(row + 1, column - 1).Content = FieldValue.Water;
            }

            if (row + 1 <= battlefield.Size && column + shipConfig.Size <= battlefield.Size) // lower right
            {
                battlefield.GetFieldByPosition(row + 1, column + shipConfig.Size).Content = FieldValue.Water;
            }
        }

        private static void SetFieldsAsWaterAroundVerticalShip(Battlefield battlefield, ShipSetting shipConfig, int row, int column)
        {
            if (row - 1 > 0) //upper side
            {
                battlefield.GetFieldByPosition(row - 1, column).Content = FieldValue.Water;
            }

            if (row + shipConfig.Size <= battlefield.Size) //lower side
            {
                battlefield.GetFieldByPosition(row + shipConfig.Size, column).Content = FieldValue.Water;
            }

            if (column - 1 > 0) //left side
            {
                for (int i = 0; i < shipConfig.Size; i++)
                {
                    battlefield.GetFieldByPosition(row + i, column - 1).Content = FieldValue.Water;
                }
            }

            if (column + 1 <= battlefield.Size) //right side
            {
                for (int i = 0; i < shipConfig.Size; i++)
                {
                    battlefield.GetFieldByPosition(row + i, column + 1).Content = FieldValue.Water;
                }
            }

            //corners
            if (row - 1 > 0 && column - 1 > 0) // upper left
            {
                battlefield.GetFieldByPosition(row - 1, column - 1).Content = FieldValue.Water;
            }

            if (row - 1 > 0 && column + 1 <= battlefield.Size) // upper right
            {
                battlefield.GetFieldByPosition(row - 1, column + 1).Content = FieldValue.Water;
            }

            if (row + shipConfig.Size <= battlefield.Size && column - 1 > 0) // lower left
            {
                battlefield.GetFieldByPosition(row + shipConfig.Size, column - 1).Content = FieldValue.Water;
            }

            if (row + shipConfig.Size <= battlefield.Size && column + 1 <= battlefield.Size) // lower right
            {
                battlefield.GetFieldByPosition(row + shipConfig.Size, column + 1).Content = FieldValue.Water;
            }
        }
    }
}
