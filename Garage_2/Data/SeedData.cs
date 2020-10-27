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
                    return;
                }

                var fake = new Faker("sv");

                //********************** Seeding members **********************************************
                List<Member> members = new List<Member>();
                var fName = fake.Name.FirstName();
                var lName = fake.Name.LastName();

                for (int i = 0; i < 20; i++)
                {
                    Member member = new Member()
                    {
                        FirstName = fName,
                        LastName = lName,
                        Phone = fake.Phone.PhoneNumber(),
                        SocialSecurityNumber = fake.Random.Digits(10, 1, 9).ToString(),
                        Email = fake.Internet.Email(fName, lName),
                        Street = fake.Address.StreetName() + fake.Random.Digits(3, 1, 9),
                        ZIP = fake.Random.Digits(5, 0, 9).ToString(),
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
                    regNum = (fake.Random.Chars('A', 'Z', 3)).ToString();
                    regNum += fake.Random.Int(001, 999).ToString();

                    ParkedVehicle parkedVehicle = new ParkedVehicle()
                    {
                        RegisterNumber = regNum,
                        Color = fake.Commerce.Color(),
                        Model = fake.Vehicle.Model(),
                        Brand = fake.Company.CompanyName(),
                        WheelsNumber = fake.Random.Int(0, 20),
                        ParkedDateTime = fake.Date.Recent(),
                        Member = fake.Random.ListItem<Member>(members), // TODO
                        VehicleType = fake.Random.ListItem<VehicleType>(vehicleTypes)
                    };

                    parkedVehicles.Add(parkedVehicle);
                }

                db.AddRange(parkedVehicles);
                db.SaveChanges();
            }
        }
    }
}