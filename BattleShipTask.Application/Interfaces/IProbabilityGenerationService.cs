using BattleShipTask.Application.Models;

namespace BattleShipTask.Application.Interfaces
{
    public interface IProbabilityGenerationService 
    {
        bool CoinFlip(int seed);
        Position GetRandomFeasibleStartingPosition(int randomizer, bool isShipHorizontal, int shipSize, int battlefieldSize);
    }
}
