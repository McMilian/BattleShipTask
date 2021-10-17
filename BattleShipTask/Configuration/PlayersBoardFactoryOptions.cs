using System;
using System.Collections.Generic;
using System.Text;

namespace BattleShipTask.Configuration
{
    public class PlayersBoardFactoryOptions
    {
        public List<ShipSetting> ShipSettings { get; set; } = new List<ShipSetting>();
    }
}
