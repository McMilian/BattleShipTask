using System;
using System.Collections.Generic;
using System.Text;
using BattleShipTask.Models;

namespace BattleShipTask.Configuration
{
    public class ApplicationOptions
    {
        public ShipsConfiguration ShipsConfiguration { get; set; } = new ShipsConfiguration();
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
