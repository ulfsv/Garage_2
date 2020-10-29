using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Channels;
using System.Threading.Tasks;

namespace Garage_2.Models
{
    public class Member
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FullName => $"{FirstName} {LastName}";
        public string Phone { get; set; }
        public string SocialSecurityNumber { get; set; }
        public string Email { get; set; }
        public string Street { get; set; }
        public string ZIP { get; set; }
        public string Adress => $"{Street}, {ZIP}";
        public string Avatar { get; set; }

        // foreign key
     //   public int ParkedVehicleId { get; set; }

        // Navigation property
        public ICollection<ParkedVehicle> ParkedVehicles { get; set; }

    }
}
