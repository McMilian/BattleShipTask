using System.Collections.Generic;

namespace BattleShipTask.Application.Configuration
{
    public class PlayersBoardFactoryOptions
    {
        public List<ShipSetting> ShipSettings { get; set; } = new();
        public int MaxRetries { get; set; }
    }
}
