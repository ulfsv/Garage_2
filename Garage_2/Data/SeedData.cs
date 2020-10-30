using Bogus;

using Garage_2.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Garage_2.Data
{
    // Seeding to tables Member, VehicleType and ParkedVehicle
    // ParkedVehicle must be last
    public static class SeedData
    {
        public static void Initialize(IServiceProvider services)
        {
            var options = services.GetRequiredService<DbContextOptions<Garage_2Context>>();

            using (var db = new Garage_2Context(options))
            {
                if (db.ParkedVehicle.Any())
                {
                    Removeposts(db);
                    //return;
                }

                var fake = new Faker("sv");

               // ********************** Seeding members ************************************************
                List<Member>  members = new List<Member>();
                
                for (int i = 0; i < 25; i++)
                {
                    var fName = fake.Name.FirstName();
                    var lName = fake.Name.LastName();

                    Member member = new Member()
                    {
                        FirstName = fName,
                        LastName = lName,
                        Phone = fake.Phone.PhoneNumber(),
                        SocialSecurityNumber = string.Join("", fake.Random.Digits(10, 1, 9)),
                        Email = fake.Internet.Email(fName, lName),
                        Street = $"{fake.Address.StreetName()} {fake.Random.Int(1, 400)}",
                        ZIP = string.Join("", fake.Random.Digits(5, 0, 9)),
                        Avatar = fake.Internet.Avatar()
                    };

                    members.Add(member);
                }

                db.AddRange(members);
                
                //*********** Seeding VehicleType *********************************************************
                var vehicleTypes = new List<VehicleType>();

                List<string> vehicleList = new List<string>()
                {
                    "Car",
                    "Boat",
                    "Bus",
                    "Airplane",
                    "Motorcycle"
                };

                foreach (string vt in vehicleList)
                {
                    VehicleType vehicleType = new VehicleType();
                    vehicleType.VehicType = vt;
                    vehicleTypes.Add(vehicleType);
                }

                db.AddRange(vehicleTypes);

                //*************************** Seeding ParkedVehicle *************************************
                List<ParkedVehicle> parkedVehicles = new List<ParkedVehicle>();

                string regNum;

                for (int i = 0; i < 20; i++)
                {
                    regNum = string.Join("", fake.Random.Chars('A', 'Z', 3));
                    regNum += fake.Random.Int(001, 999).ToString();

                    ParkedVehicle parkedVehicle = new ParkedVehicle()
                    {
                        RegisterNumber = regNum,
                        Color = fake.Commerce.Color(),
                        Model = fake.Vehicle.Model(),
                        Brand = fake.Vehicle.Manufacturer(),
                        WheelsNumber = fake.Random.Int(0, 20),
                        ParkedDateTime = fake.Date.Recent(),

                        // Foreign keys
                        Member = fake.Random.ListItem<Member>(members), 
                        VehicleType = fake.Random.ListItem<VehicleType>(vehicleTypes)
                    };

                    parkedVehicles.Add(parkedVehicle);
                }

                db.AddRange(parkedVehicles);
                

                // ********************** Seeding ParkingSpaces *************************************************
                List<ParkingSpace> parkingSpaces = new List<ParkingSpace>();
                int nrOfParkingSpaces = 20;

                for (int i = 0; i < nrOfParkingSpaces; i++)
                {
                    ParkingSpace parkingSpace = new ParkingSpace()
                    {
                        // Foreign key
                        ParkedVehicleId = i,

                        // Foreign keys
                        //ParkedVehicle = fake.Random.ListItem<ParkedVehicle>(parkedVehicles),
                        ParkedVehicle = parkedVehicles[i]
                    };

                    parkingSpaces.Add(parkingSpace);
                }

                db.AddRange(parkingSpaces);

                db.SaveChanges();
            }
        }


        private static void Removeposts(Garage_2Context db)
        {
            db.ParkedVehicle.RemoveRange(db.ParkedVehicle);
            db.Member.RemoveRange(db.Member);
            db.VehicleType.RemoveRange(db.VehicleType);
            db.ParkingSpace.RemoveRange(db.ParkingSpace);
        }
    }
}