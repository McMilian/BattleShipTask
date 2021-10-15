using BattleShipTask.Models;
using System.Collections.Generic;

namespace BattleShipTask.Interfaces
{
    public interface IShipsLocationGenerationService
    {
        Battlefield GenerateBattlefieldWithShips(int size, ShipsConfiguration shipsConfiguration);
        IEnumerable<Ship> GenerateShipsLocation(int battlefieldSize, ShipsConfiguration shipsConfiguration);
        IEnumerable<Ship> GenerateShipsLocationWithSeed(int battlefieldSize, ShipsConfiguration shipsConfiguration, int seed);
    }
}
