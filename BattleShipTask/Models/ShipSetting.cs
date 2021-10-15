using System;
using System.Collections.Generic;
using System.Text;

namespace BattleShipTask.Models
{
    public class ShipSetting
    {
        public int Size { get; }
        public int Count { get; }

        public ShipSetting(int size, int count)
        {
            Size = size;
            Count = count;
        }
    }
}
