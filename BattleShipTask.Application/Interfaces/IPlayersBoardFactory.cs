using BattleShipTask.Application.Models;

namespace BattleShipTask.Application.Interfaces
{
    public interface IPlayersBoardFactory
    {
        PlayersBoard Create(int battlefieldSize, int seed);
    }
}
