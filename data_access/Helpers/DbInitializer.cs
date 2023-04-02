using EntityFrameworkWithMigration.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace EntityFrameworkWithMigration.Helpers
{
    public static class DbInitializer
    {
        public static void SeedAirplanes(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Airplane>().HasData(new Airplane[]
           {
                new Airplane()
                {
                     Id = 1,
                     Model = "An 727",
                     MaxPassangers = 120
                },
                 new Airplane()
                {
                     Id = 2,
                     Model = "Boeing 144",
                     MaxPassangers = 90
                }
           });
        }
        public static void SeedFlights(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Flight>().HasData(new Flight[]
          {
                new Flight()
                {
                     Number = 1,
                     ArrivalCity = "Lviv",
                     DeparturelCity = "Kyiv",
                     ArrivalTime = new DateTime(2023,5,6),
                     DeparturelTime = new DateTime(2023,5,6),
                     AirplaneId = 1
                },
                new Flight()
                {
                     Number = 2,
                     ArrivalCity = "Lviv",
                     DeparturelCity = "Warshaw",
                     ArrivalTime = new DateTime(2023,10,16),
                     DeparturelTime = new DateTime(2023,10,17),
                     AirplaneId = 2
                },
                new Flight()
                {
                     Number = 3,
                     ArrivalCity = "Rivne",
                     DeparturelCity = "Warshaw",
                     ArrivalTime = new DateTime(2023,5,6),
                     DeparturelTime = new DateTime(2023,5,6),
                     AirplaneId = 2
                }
          });
        }
    }
}
