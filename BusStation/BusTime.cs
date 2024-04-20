using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusStation
{
    public class BusTime
    {
        public int ID { get; set; }
        public Bus Bus { get; set; } = new Bus();
        public TimeOnly Time { get; set; }
    }
}
