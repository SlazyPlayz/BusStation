using BusStation;
using Microsoft.EntityFrameworkCore;

AddData();
PrintData();

static void AddData()
{
    using (var context = new BusStationContext())
    {
        context.Database.EnsureCreated();

        List<Bus> buses = new List<Bus>();

        if (context.Buses.Any())
        {
            buses =
            [
                new Bus
                {
                    StartingLocation = "Sofia",
                    EndingLocation = "Plovdiv",
                    Type = BusType.Minibus,
                    DriverName = "Pesho"
                },
                new Bus
                {
                    StartingLocation = "Sunny Beach",
                    EndingLocation = "Ravda",
                    Type = BusType.DoubleDecker,
                    DriverName = "Ivan"
                },
                new Bus
                {
                    StartingLocation = "Plovdiv",
                    EndingLocation = "Thessaloniki",
                    Type = BusType.Bus,
                    DriverName = "Georgi"
                },
                new Bus
                {
                    StartingLocation = "Svilengrad",
                    EndingLocation = "Varna",
                    Type = BusType.Bus,
                    DriverName = "Dimitar"
                },
                new Bus
                {
                    StartingLocation = "Plovdiv",
                    EndingLocation = "Ruse",
                    Type = BusType.Bus,
                    DriverName = "Alex"
                },
                new Bus
                {
                    StartingLocation = "Pleven",
                    EndingLocation = "Plovdiv",
                    Type = BusType.Bus,
                    DriverName = "Simeon"
                }
            ];
            context.Buses.AddRange(buses);
        }
        else buses = [.. context.Buses];

        if (context.Stations.Any())
        {
            List<Station> stations =
            [
                new()
                {
                    PlaceName = "Plovdiv",
                    Country = "Bulgaria",
                    Arrivals =
                    [
                        new()
                        {
                            Bus = buses.First(x => x.EndingLocation.Equals("Plovdiv")),
                            Time = new TimeOnly(11, 30)
                        },
                        new()
                        {
                            Bus = buses.Last(x => x.EndingLocation.Equals("Plovdiv")),
                            Time = new TimeOnly(16, 50)
                        }
                    ],
                    Departures =
                    [
                        new()
                        {
                            Bus = buses.First(x => x.StartingLocation.Equals("Plovdiv")),
                            Time = new TimeOnly(12, 00)
                        },
                        new()
                        {
                            Bus = buses.Last(x => x.StartingLocation.Equals("Plovdiv")),
                            Time = new TimeOnly(09, 30)
                        }
                    ]
                },
                new()
                {
                    PlaceName = "Sofia",
                    Country = "Bulgaria",
                    Departures =
                    [
                        new()
                        {
                            Bus = buses.First(x => x.StartingLocation.Equals("Sofia")),
                            Time = new TimeOnly(09, 00)
                        }
                    ]
                },
                new()
                {
                    PlaceName = "Sunny Beach",
                    Country = "Bulgaria",
                    Departures =
                    [
                        new()
                        {
                            Bus = buses.First(x => x.StartingLocation.Equals("Sofia")),
                            Time = new TimeOnly(11, 00)
                        }
                    ]
                },
                new()
                {
                    PlaceName = "Ravda",
                    Country = "Bulgaria",
                    Arrivals =
                    [
                        new()
                        {
                            Bus = buses.First(x => x.EndingLocation.Equals("Ravda")),
                            Time = new TimeOnly(11, 30)
                        }
                    ]
                },
                new()
                {
                    PlaceName = "Thessaloniki",
                    Country = "Greece",
                    Arrivals =
                    [
                        new()
                        {
                            Bus = buses.First(x => x.EndingLocation.Equals("Thessaloniki")),
                            Time = new TimeOnly(16, 30)
                        }
                    ]
                },
                new()
                {
                    PlaceName = "Svilengrad",
                    Country = "Bulgaria",
                    Departures =
                    [
                        new()
                        {
                            Bus = buses.First(x => x.StartingLocation.Equals("Svilengrad")),
                            Time = new TimeOnly(08, 30)
                        }
                    ]
                },
                new()
                {
                    PlaceName = "Varna",
                    Country = "Bulgaria",
                    Arrivals =
                    [
                        new()
                        {
                            Bus = buses.First(x => x.EndingLocation.Equals("Varna")),
                            Time = new TimeOnly(21, 40)
                        }
                    ]
                },
                new()
                {
                    PlaceName = "Ruse",
                    Country = "Bulgaria",
                    Arrivals =
                    [
                        new()
                        {
                            Bus = buses.First(x => x.EndingLocation.Equals("Ruse")),
                            Time = new TimeOnly(21, 40)
                        }
                    ]
                },
                new()
                {
                    PlaceName = "Pleven",
                    Country = "Bulgaria",
                    Arrivals =
                    [
                        new()
                        {
                            Bus = buses.First(x => x.EndingLocation.Equals("Pleven")),
                            Time = new TimeOnly(10, 00)
                        }
                    ]
                }
            ];

            context.Stations.AddRange(stations);
        }

        context.SaveChanges();
    }
}
static void PrintData()
{
    using (var context = new BusStationContext())
    {
        context.Database.EnsureCreated();

        Console.WriteLine("Buses: ");
        context.Buses.ForEachAsync(x => Console.WriteLine(x.GetData()));

        Console.WriteLine();

        Console.WriteLine("Bus stations: ");
        context.Stations.ForEachAsync(x => x.PrintData());
    }
}