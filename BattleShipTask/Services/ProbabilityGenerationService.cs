using BattleShipTask.Interfaces;
using BattleShipTask.Models;
using System;

namespace BattleShipTask.Services
{
    public class ProbabilityGenerationService : IProbabilityGenerationService
    {
        public bool CoinFlip(int seed)
        {
            return new Random(seed + 13).Next(1, 100) <= 50;
        }

        public Position GetRandomStartingPosition(int seed, bool isShipHorizontal, int shipSize, int battlefieldSize)
        {
            Position startingPosition;

            if (isShipHorizontal)
            {
                startingPosition = new Position(new Random(seed * 2 + 67).Next(1, battlefieldSize + 1),
                        new Random(seed * 3 + 17).Next(1, battlefieldSize - shipSize + 2));
            }
            else
            {
                startingPosition = new Position(new Random(seed * 4 + 99).Next(1, battlefieldSize - shipSize + 2),
                    new Random(seed * 5 + 54).Next(1, battlefieldSize + 1));
            }

            return startingPosition;
        }
    }
}
