using BattleShipTask.Models;

namespace BattleShipTask.Interfaces
{
    public interface IShipFactory
    {
        Ship Create(int size, Position startingPoint, bool isHorizontallyPlaced);
    }
}
