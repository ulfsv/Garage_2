using Bogus;
using Garage_2.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Garage_2.Data
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider services)
        {
            var options = services.GetRequiredService<DbContextOptions<Garage_2Context>>();

            using (var db = new Garage_2Context(options))
            {
                if (db.ParkedVehicle.Any())
                {
                    //db.ParkedVehicle.RemoveRange(db.ParkedVehicle)
                    return;
                }

                var fake = new Faker("sv");

                //********************** Seeding members **********************************************

                var parkingspaces = new Garage[20];
                    
                for (int i = 0; i < 20; i++)
                    {
                        
                        var objGarage = new Garage { Id = i, ParkingSpaceNum = i };
                        parkingspaces[i] = objGarage;
                        db.AddRange(objGarage);
                    }
                        
                /*foreach (var c in parkingspaces)
                {
                    //parkingspaces.Add(c);

                    db.AddRange(c);

                    //parkedVehicles.Add(parkedVehicle);
                }*/

                
                //List<Garage> garages = new List<Garage>();
                //var parkingspaces = new Garage[]
                //{
                //            new Garage{Id=1,ParkingSpaceNum=1},
                //            new Garage{Id=2,ParkingSpaceNum=2},
                //            new Garage{Id=3,ParkingSpaceNum=3},
                //            new Garage{Id=4,ParkingSpaceNum=4},
                //            new Garage{Id=5,ParkingSpaceNum=5},
                //            new Garage{Id=6,ParkingSpaceNum=6},
                //            new Garage{Id=7,ParkingSpaceNum=7},
                //            new Garage{Id=8,ParkingSpaceNum=8},
                //            new Garage{Id=9,ParkingSpaceNum=9},
                //            new Garage{Id=10,ParkingSpaceNum=10},
                //            new Garage{Id=11,ParkingSpaceNum=11},
                //            new Garage{Id=12,ParkingSpaceNum=12},
                //            new Garage{Id=13,ParkingSpaceNum=13},
                //            new Garage{Id=14,ParkingSpaceNum=14},
                //            new Garage{Id=15,ParkingSpaceNum=15},
                //            new Garage{Id=16,ParkingSpaceNum=16},
                //            new Garage{Id=17,ParkingSpaceNum=17},
                //            new Garage{Id=18,ParkingSpaceNum=18},
                //            new Garage{Id=19,ParkingSpaceNum=19},
                //            new Garage{Id=20,ParkingSpaceNum=20}                           
                //};
                //foreach (Garage c in parkingspaces)
                //{
                //    //parkingspaces.Add(c);

                //    db.AddRange(garages);

                    //parkedVehicles.Add(parkedVehicle);                }        

                List<Member> members = new List<Member>();
                
                for (int i = 0; i < 20; i++)
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
                var parkedVehicles = new List<ParkedVehicle>();

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
                        VehicleType = fake.Random.ListItem<VehicleType>(vehicleTypes),
                        Garage = ListItem<Garage>(garages)
                    };

                    parkedVehicles.Add(parkedVehicle);
                }

                db.AddRange(parkedVehicles);
                db.SaveChanges();
            }
        }
    }
}