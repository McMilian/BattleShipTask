using BattleShipTask.Application.Models;

namespace BattleShipTask.Application.Interfaces
{
    public interface IShipFactory
    {
        Ship Create(int size, Position startingPoint, bool isHorizontallyPlaced);
    }
}
