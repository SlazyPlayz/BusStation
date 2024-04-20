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
        public int StartingLocationID { get; set; }
        public int EndingLocationID { get; set; }
        public Station StartingLocation { get; set; }
        public Station EndingLocation { get; set;}
        public BusType Type { get; set; }
        public string DriverName { get; set; } = string.Empty;
        public TimeOnly Departure { get; set; }
        public TimeOnly Arrival { get; set; }

        public string GetData()
        {
            return String.Format($"{StartingLocation.Location} - {EndingLocation.Location} ({Type}) -> {DriverName}");
        }
    }

    public enum BusType
    {
        Bus, Minibus, DoubleDecker
    }
}
