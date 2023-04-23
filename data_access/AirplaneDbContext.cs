using data_access.Entities;
using EntityFrameworkWithMigration.Entities;
using EntityFrameworkWithMigration.Helpers;
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
        public DbSet<Credentials> Credentials { get; set; }
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
            modelBuilder.SeedAirplanes();
            modelBuilder.SeedFlights();
            modelBuilder.SeedCredentials();
            modelBuilder.SeedClients();


            //Fluent API configuration 
            modelBuilder.Entity<Credentials>()
                .HasOne(c => c.Client)
                .WithOne(c => c.Credentials)
                .HasForeignKey<Client>(c => c.CredentialsId);

            modelBuilder.Entity<Airplane>()
                .Property(a => a.Model)
                .HasMaxLength(100)
                .IsRequired();

            modelBuilder.Entity<Client>().ToTable("Passangers");
            modelBuilder.Entity<Client>()
                .Property(c => c.Name)
                .HasMaxLength(200)
                .IsRequired()
                .HasColumnName("FirstName");
            modelBuilder.Entity<Client>()
              .Property(c => c.Email)
              .HasMaxLength(50)
              .IsRequired();

            modelBuilder.Entity<Flight>().HasKey(f => f.Number);
            modelBuilder.Entity<Flight>()
                .Property(f => f.DeparturelCity)
                .HasMaxLength(100)
                .IsRequired();
            modelBuilder.Entity<Flight>()
                .Property(f => f.ArrivalCity)
                .HasMaxLength(100)
                .IsRequired();

            //Relationships configuration
            modelBuilder.Entity<Client>().HasMany(c => c.Flights).WithMany(f => f.Clients);
            //modelBuilder.Entity<Flight>().HasMany(f => f.Clients).WithMany(c => c.Flights);
            modelBuilder.Entity<Flight>()
                .HasOne(f => f.Airplane)
                .WithMany(a => a.Flights)
                .HasForeignKey(f => f.AirplaneId);


        }
    }
}
