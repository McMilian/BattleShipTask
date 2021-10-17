using BattleShipTask.Models;

namespace BattleShipTask.Interfaces
{
    public interface IPlayersBoardFactory
    {
        PlayersBoard Create(int battlefieldSize, int seed);
    }
}
