using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusStation
{
    public class BusStationContext : DbContext
    {
        public DbSet<Bus> Buses { get; set; }
        public DbSet<Station> Stations { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=bus_station;Trusted_Connection=True;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Bus>()
                .Property(b => b.Type)
                .HasConversion(
                    v => v.ToString(),
                    v => (BusType)Enum.Parse(typeof(BusType), v));

            base.OnModelCreating(modelBuilder);
        }
    }
}
