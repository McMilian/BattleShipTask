using System.Collections.Generic;

namespace BattleShipTask.Configuration
{
    public class PlayersBoardFactoryOptions
    {
        public List<ShipSetting> ShipSettings { get; set; } = new List<ShipSetting>();
        public int MaxRetries { get; set; }
    }
}
