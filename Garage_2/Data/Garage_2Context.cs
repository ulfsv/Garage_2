using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Garage_2.Models;

namespace Garage_2.Data
{
    public class Garage_2Context : DbContext
    {
        public Garage_2Context(DbContextOptions<Garage_2Context> options)
            : base(options)
        {
        }

        public DbSet<Garage_2.Models.ParkedVehicle> ParkedVehicle { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            /*modelBuilder.Entity<ParkedVehicle>().HasData(
                new ParkedVehicle
                {
                    Id = 1,
                    VehicleType = new VehicleType(),
                    RegisterNumber = "abc123",
                    Color = "Blue",
                    Model = "A1",
                    Brand = "Airbus",
                    WheelsNumber = 10,
                    ParkedDateTime = DateTime.Now.AddHours(-2).AddMinutes(-2)     // new DateTime(2018, 3, 1, 7, 0, 0),
                },

                new ParkedVehicle
                {
                    Id = 2,
                    VehicleType = new VehicleType(),
                    RegisterNumber = "dkl785",
                    Color = "Black",
                    Model = "B2",
                    Brand = "Volvo",
                    WheelsNumber = 4,
                    ParkedDateTime = DateTime.Now
                },

                new ParkedVehicle
                {
                    Id = 3,
                    VehicleType = new VehicleType(),
                    RegisterNumber = "uio159",
                    Color = "Red",
                    Model = "C3",
                    Brand = "Saga",
                    WheelsNumber = 0,
                    ParkedDateTime = DateTime.Now.AddMinutes(-3)
                }); ;
            */
        }

        public DbSet<Garage_2.Models.Member> Member { get; set; }

    }
}
