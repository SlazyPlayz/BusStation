using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusStation
{
    public class Bus
    {
        public int ID { get; set; }
        public string StartingLocation { get; set; } = string.Empty;
        public string EndingLocation { get; set;} = string.Empty;
        public BusType Type { get; set; }
        public string DriverName { get; set; } = string.Empty;

        public string GetData() => String.Format($"{StartingLocation} - {EndingLocation} ({Type}) -> {DriverName}");
    }

    public enum BusType
    {
        Bus, Minibus, DoubleDecker
    }
}
