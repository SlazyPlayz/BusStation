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

            modelBuilder.Entity<Bus>()
                .HasOne(b => b.EndingLocation)
                .WithMany(s => s.Arrivals)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Bus>()
                .HasOne(b => b.StartingLocation)
                .WithMany(s => s.Departures)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Station>()
                .HasMany(s => s.Arrivals)
                .WithOne(b => b.EndingLocation)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Station>()
                .HasMany(s => s.Departures)
                .WithOne(b => b.StartingLocation)
                .OnDelete(DeleteBehavior.Restrict);

            base.OnModelCreating(modelBuilder);
        }
    }
}
