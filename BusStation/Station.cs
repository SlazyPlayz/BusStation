using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusStation
{
    public class Station
    {
        public int ID { get; set; }
        public string Location { get; set; } = string.Empty;
        public string Country { get; set; } = string.Empty;
        public List<Bus> Arrivals { get; set; } = [];
        public List<Bus> Departures { get; set; } = [];

        public void PrintData()
        {
            Console.WriteLine($"Location: {Location} ({Country})");
            Arrivals.ForEach(x => Console.WriteLine($"{x.Arrival.ToShortTimeString()}: {x.GetData()}"));
            Departures.ForEach(x => Console.WriteLine($"{x.Departure.ToShortTimeString()}: {x.GetData()}"));
            Console.WriteLine();
        }
    }
}
