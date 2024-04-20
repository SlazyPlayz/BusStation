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
        public string PlaceName { get; set; } = string.Empty;
        public string Country { get; set; } = string.Empty;
        public List<BusTime> Arrivals { get; set; } = [];
        public List<BusTime> Departures { get; set; } = [];

        public void PrintData()
        {
            Console.WriteLine($"Location: {PlaceName} ({Country})");
            Arrivals.ForEach(x => Console.WriteLine($"{x.Time.ToShortTimeString()}: {x.Bus.GetData()}"));
            Departures.ForEach(x => Console.WriteLine($"{x.Time.ToShortTimeString()}: {x.Bus.GetData()}"));
        }
    }
}
