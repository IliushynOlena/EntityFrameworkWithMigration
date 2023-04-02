﻿// <auto-generated />
using System;
using EntityFrameworkWithMigration;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace EntityFrameworkWithMigration.Migrations
{
    [DbContext(typeof(AirplaneDbContext))]
    partial class AirplaneDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.17")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("ClientFlight", b =>
                {
                    b.Property<int>("ClientsId")
                        .HasColumnType("int");

                    b.Property<int>("FlightsNumber")
                        .HasColumnType("int");

                    b.HasKey("ClientsId", "FlightsNumber");

                    b.HasIndex("FlightsNumber");

                    b.ToTable("ClientFlight");
                });

            modelBuilder.Entity("EntityFrameworkWithMigration.Entities.Airplane", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("MaxPassangers")
                        .HasColumnType("int");

                    b.Property<string>("Model")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.ToTable("Airplanes");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            MaxPassangers = 120,
                            Model = "An 727"
                        },
                        new
                        {
                            Id = 2,
                            MaxPassangers = 90,
                            Model = "Boeing 144"
                        });
                });

            modelBuilder.Entity("EntityFrameworkWithMigration.Entities.Client", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime?>("Birthday")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)")
                        .HasColumnName("FirstName");

                    b.Property<int?>("Rating")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Passangers");
                });

            modelBuilder.Entity("EntityFrameworkWithMigration.Entities.Flight", b =>
                {
                    b.Property<int>("Number")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AirplaneId")
                        .HasColumnType("int");

                    b.Property<string>("ArrivalCity")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<DateTime>("ArrivalTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("DeparturelCity")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<DateTime>("DeparturelTime")
                        .HasColumnType("datetime2");

                    b.HasKey("Number");

                    b.HasIndex("AirplaneId");

                    b.ToTable("Flights");

                    b.HasData(
                        new
                        {
                            Number = 1,
                            AirplaneId = 1,
                            ArrivalCity = "Lviv",
                            ArrivalTime = new DateTime(2023, 5, 6, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            DeparturelCity = "Kyiv",
                            DeparturelTime = new DateTime(2023, 5, 6, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Number = 2,
                            AirplaneId = 2,
                            ArrivalCity = "Lviv",
                            ArrivalTime = new DateTime(2023, 10, 16, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            DeparturelCity = "Warshaw",
                            DeparturelTime = new DateTime(2023, 10, 17, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Number = 3,
                            AirplaneId = 2,
                            ArrivalCity = "Rivne",
                            ArrivalTime = new DateTime(2023, 5, 6, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            DeparturelCity = "Warshaw",
                            DeparturelTime = new DateTime(2023, 5, 6, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        });
                });

            modelBuilder.Entity("ClientFlight", b =>
                {
                    b.HasOne("EntityFrameworkWithMigration.Entities.Client", null)
                        .WithMany()
                        .HasForeignKey("ClientsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("EntityFrameworkWithMigration.Entities.Flight", null)
                        .WithMany()
                        .HasForeignKey("FlightsNumber")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("EntityFrameworkWithMigration.Entities.Flight", b =>
                {
                    b.HasOne("EntityFrameworkWithMigration.Entities.Airplane", "Airplane")
                        .WithMany("Flights")
                        .HasForeignKey("AirplaneId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Airplane");
                });

            modelBuilder.Entity("EntityFrameworkWithMigration.Entities.Airplane", b =>
                {
                    b.Navigation("Flights");
                });
#pragma warning restore 612, 618
        }
    }
}
