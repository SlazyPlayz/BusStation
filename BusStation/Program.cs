using BusStation;
using Microsoft.EntityFrameworkCore;

await AddData();
await PrintData();

async static Task AddData()
{
    using var context = new BusStationContext();
    context.Database.EnsureCreated();

    if (!context.Stations.Any())
    {
        List<Station> stations =
        [
            new()
                {
                    Location = "Plovdiv",
                    Country = "Bulgaria"
                },
                new()
                {
                    Location = "Sofia",
                    Country = "Bulgaria"
                },
                new()
                {
                    Location = "Sunny Beach",
                    Country = "Bulgaria"
                },
                new()
                {
                    Location = "Ravda",
                    Country = "Bulgaria"
                },
                new()
                {
                    Location = "Thessaloniki",
                    Country = "Greece"
                },
                new()
                {
                    Location = "Svilengrad",
                    Country = "Bulgaria"
                },
                new()
                {
                    Location = "Varna",
                    Country = "Bulgaria"
                },
                new()
                {
                    Location = "Ruse",
                    Country = "Bulgaria"
                },
                new()
                {
                    Location = "Pleven",
                    Country = "Bulgaria"
                }
        ];

        context.Stations.AddRange(stations);
        await context.SaveChangesAsync();
    }

    if (!context.Buses.Any())
    {
        var stations = await context.Stations.ToArrayAsync();

        List<Bus> buses =
        [
            new()
                {
                    //09:00 -> 11:30
                    StartingLocation = stations.First(x => x.Location.Equals("Sofia")),
                    EndingLocation = stations.First(x => x.Location.Equals("Plovdiv")),
                    Departure = new TimeOnly(09, 00),
                    Arrival = new TimeOnly(11, 30),
                    Type = BusType.Minibus,
                    DriverName = "Pesho"
                },
                new()
                {
                    //11:00 -> 11:30
                    StartingLocation = stations.First(x => x.Location.Equals("Sunny Beach")),
                    EndingLocation = stations.First(x => x.Location.Equals("Ravda")),
                    Departure = new TimeOnly(11, 00),
                    Arrival = new TimeOnly(11, 30),
                    Type = BusType.DoubleDecker,
                    DriverName = "Ivan"
                },
                new()
                {
                    // 12:00 -> 16:30
                    StartingLocation = stations.First(x => x.Location.Equals("Plovdiv")),
                    EndingLocation = stations.First(x => x.Location.Equals("Thessaloniki")),
                    Departure = new TimeOnly(12, 00),
                    Arrival = new TimeOnly(16, 30),
                    Type = BusType.Bus,
                    DriverName = "Georgi"
                },
                new()
                {
                    //08:30 -> 21:40
                    StartingLocation = stations.First(x => x.Location.Equals("Svilengrad")),
                    EndingLocation = stations.First(x => x.Location.Equals("Varna")),
                    Departure = new TimeOnly(08, 30),
                    Arrival = new TimeOnly(21, 40),
                    Type = BusType.Bus,
                    DriverName = "Dimitar"
                },
                new()
                {
                    //09:30 -> 19:30
                    StartingLocation = stations.First(x => x.Location.Equals("Plovdiv")),
                    EndingLocation = stations.First(x => x.Location.Equals("Ruse")),
                    Departure = new TimeOnly(09, 30),
                    Arrival = new TimeOnly(19, 30),
                    Type = BusType.Bus,
                    DriverName = "Alex"
                },
                new()
                {
                    //10:00 -> 16:50
                    StartingLocation = stations.First(x => x.Location.Equals("Pleven")),
                    EndingLocation = stations.First(x => x.Location.Equals("Plovdiv")),
                    Departure = new TimeOnly(10, 00),
                    Arrival = new TimeOnly(16, 50),
                    Type = BusType.Bus,
                    DriverName = "Simeon"
                }
        ];
        context.Buses.AddRange(buses);
        await context.SaveChangesAsync();
    }
}
async static Task PrintData()
{
    using var context = new BusStationContext();
    context.Database.EnsureCreated();

    //Janky workaround to make sure that the buses get loaded before the stations
    await context.Buses.Include(b => b.StartingLocation).Include(b => b.EndingLocation).ForEachAsync(x => x.GetData());

    Console.WriteLine("Bus stations: ");
    await context.Stations.Include(s => s.Arrivals).Include(s => s.Departures).ForEachAsync(x => x.PrintData());
}