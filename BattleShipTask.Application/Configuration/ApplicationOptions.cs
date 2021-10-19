using System.Collections.Generic;

namespace BattleShipTask.Application.Configuration
{
    public class ApplicationOptions
    {
        public ShipsConfiguration ShipsConfiguration { get; set; } = new();
        public int MaxNumberOfRandomTries { get; set; }
        public bool ShowOpponentsShips { get; set; }
    }

    public sealed class ShipsConfiguration 
    {
        public List<ShipSetting> ShipSettings { get; set; } = new();
    }

    public sealed class ShipSetting
    {
        public int Size { get; set; }
        public int Count { get; set; }
    }
}
