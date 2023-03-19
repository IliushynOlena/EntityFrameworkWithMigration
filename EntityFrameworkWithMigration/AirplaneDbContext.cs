using EntityFrameworkWithMigration.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFrameworkWithMigration
{
    public class AirplaneDbContext : DbContext
    {
        public AirplaneDbContext()
        {
           //this.Database.EnsureDeleted();
           //this.Database.EnsureCreated();
        }
        //Collections
        //Airplanes
        //Clients
        //Flights
        public DbSet<Client> Clients { get; set; }
        public DbSet<Airplane> Airplanes { get; set; }
        public DbSet<Flight> Flights { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

            optionsBuilder.UseSqlServer(@"Data Source=DESKTOP-3HG9UVT\SQLEXPRESS;
                                            Initial Catalog = NewAiplaneDbMigration;
                                            Integrated Security=True;
                                            Connect Timeout=2;Encrypt=False;
                                            TrustServerCertificate=False;
                                            ApplicationIntent=ReadWrite;
                                            MultiSubnetFailover=False");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            //initialization or Seeder
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
