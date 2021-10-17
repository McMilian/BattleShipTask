using BattleShipTask.Models;

namespace BattleShipTask.Interfaces
{
    public interface IPlayersBoardFactory
    {
        PlayersBoard Create(int battlefieldSize, ShipsConfiguration shipsConfiguration, int seed);
    }
}
