using BattleShipTask.Interfaces;
using BattleShipTask.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BattleShipTask.Services
{
    public class ProbabilityGenerationService : IProbabilityGenerationService
    {
        public bool CoinFlip()
        {
            return new Random().Next(1, 100) <= 50;
        }
        
        public int GetRandomNumberFromRange(int minValue, int maxValue)
        {
            return new Random().Next(minValue, maxValue);
        }
    }
}
