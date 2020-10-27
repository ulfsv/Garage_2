﻿// <auto-generated />
using System;
using Garage_2.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Garage_2.Migrations
{
    [DbContext(typeof(Garage_2Context))]
    [Migration("20201027085852_next2")]
    partial class next2
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.9")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Garage_2.Models.Member", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Avatar")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Phone")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SocialSecurityNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Street")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ZIP")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Member");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Avatar = "https://www.befunky.com/images/wp/wp-2014-08-milky-way-1023340_1280.jpg?auto=webp&format=jpg&width=1600",
                            Email = "s.Jonsson@gmail.com",
                            FirstName = "Sandy",
                            LastName = "Jonsson",
                            Phone = "0715184655",
                            SocialSecurityNumber = "199805200111",
                            Street = "Kvarnväg 12",
                            ZIP = "0046"
                        },
                        new
                        {
                            Id = 2,
                            Avatar = "https://www.befunky.com/images/wp/wp-2014-08-milky-way-1023340_1280.jpg?auto=webp&format=jpg&width=1600",
                            Email = "s.gg@gmail.com",
                            FirstName = "Sandrs",
                            LastName = "Petersson",
                            Phone = "0700084655",
                            SocialSecurityNumber = "19280509415511",
                            Street = "Gamlebyväg 10",
                            ZIP = "0046"
                        });
                });

            modelBuilder.Entity("Garage_2.Models.ParkedVehicle", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Brand")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Color")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("MemberId")
                        .HasColumnType("int");

                    b.Property<string>("Model")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("ParkedDateTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("RegisterNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("VehicleTypeId")
                        .HasColumnType("int");

                    b.Property<string>("VehicleTypeVehicType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("WheelsNumber")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("MemberId");

                    b.HasIndex("VehicleTypeId");

                    b.ToTable("ParkedVehicle");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Brand = "Airbus",
                            Color = "Blue",
                            MemberId = 0,
                            Model = "A1",
                            ParkedDateTime = new DateTime(2020, 10, 27, 7, 56, 52, 394, DateTimeKind.Local).AddTicks(4177),
                            RegisterNumber = "ABC123",
                            VehicleTypeId = 0,
                            VehicleTypeVehicType = "Car",
                            WheelsNumber = 10
                        },
                        new
                        {
                            Id = 2,
                            Brand = "Volvo",
                            Color = "Black",
                            MemberId = 0,
                            Model = "B2",
                            ParkedDateTime = new DateTime(2020, 10, 27, 9, 58, 52, 398, DateTimeKind.Local).AddTicks(7020),
                            RegisterNumber = "DKL785",
                            VehicleTypeId = 0,
                            VehicleTypeVehicType = "Bus",
                            WheelsNumber = 4
                        },
                        new
                        {
                            Id = 3,
                            Brand = "Saga",
                            Color = "Red",
                            MemberId = 0,
                            Model = "C3",
                            ParkedDateTime = new DateTime(2020, 10, 27, 9, 55, 52, 398, DateTimeKind.Local).AddTicks(7075),
                            RegisterNumber = "UIO159",
                            VehicleTypeId = 0,
                            VehicleTypeVehicType = "Boat",
                            WheelsNumber = 0
                        });
                });

            modelBuilder.Entity("Garage_2.Models.VehicleType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("VehicType")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("VehicleType");

                    b.HasData(
                        new
                        {
                            Id = 1111,
                            VehicType = "Tractor"
                        },
                        new
                        {
                            Id = 2,
                            VehicType = "Tractor2"
                        },
                        new
                        {
                            Id = 355,
                            VehicType = "Tractor3"
                        },
                        new
                        {
                            Id = 201,
                            VehicType = "Tractor2"
                        },
                        new
                        {
                            Id = 319,
                            VehicType = "Tractor3"
                        });
                });

            modelBuilder.Entity("Garage_2.Models.ParkedVehicle", b =>
                {
                    b.HasOne("Garage_2.Models.Member", "Member")
                        .WithMany("ParkedVehicles")
                        .HasForeignKey("MemberId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Garage_2.Models.VehicleType", "VehicleType")
                        .WithMany("ParkedVehicles")
                        .HasForeignKey("VehicleTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
