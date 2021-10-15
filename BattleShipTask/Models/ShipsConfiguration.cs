using System.Collections.Generic;

namespace BattleShipTask.Models
{
    public class ShipsConfiguration
    {
        public IEnumerable<ShipSetting> ShipSettings { get; }

        public ShipsConfiguration()
        {
            ShipSettings = new List<ShipSetting>()
            {
                new ShipSetting(5, 1),
                new ShipSetting(4, 1),
                new ShipSetting(3, 2),
                new ShipSetting(2, 2),
                new ShipSetting(1, 1),
            };
        }
    }
}
