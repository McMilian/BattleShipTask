using BattleShipTask.Models;

namespace BattleShipTask.Interfaces
{
    public interface IProbabilityGenerationService 
    {
        bool CoinFlip(int seed);
        Position GetRandomStartingPosition(int randomizer, bool isShipHorizontal, int shipSize, int battlefieldSize);
    }
}
