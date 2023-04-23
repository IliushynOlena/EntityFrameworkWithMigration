using data_access.Entities;
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
        public static void SeedAirplanes(this ModelBuilder modelBuilder)//extention
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
        public static void SeedCredentials(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Credentials>().HasData( new Credentials[]
            {
                new Credentials(){ Id = 1, Login = "super", Password = "1234"},
                new Credentials(){ Id = 2, Login = "superpuper", Password = "1111"},
                new Credentials(){ Id = 3, Login = "user", Password = "2222"}
            });
        }
        public static void SeedClients(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Client>().HasData(new Client[]
            {
                new Client(){  
                    CredentialsId = 1, 
                    Name= "Victor", 
                    Email = "victor@gmail.com", 
                    Birthday = new DateTime(2000,5,4), 
                    Rating = 10 },
                 new Client(){
                    CredentialsId = 2,
                    Name= "Petro",
                    Email = "petro@gmail.com",
                    Birthday = new DateTime(1999,5,4),
                    Rating = 8 },

            });
        }

    }
}
