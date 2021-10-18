using System.Collections.Generic;

namespace BattleShipTask.Configuration
{
    public class ApplicationOptions
    {
        public ShipsConfiguration ShipsConfiguration { get; set; } = new ShipsConfiguration();
        public int MaxNumberOfRandomTries { get; set; }
    }

    public sealed class ShipsConfiguration 
    {
        public List<ShipSetting> ShipSettings { get; set; } = new List<ShipSetting>();
    }

    public sealed class ShipSetting
    {
        public int Size { get; set; }
        public int Count { get; set; }
    }
}
