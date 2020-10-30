using Garage_2.Data;
using Garage_2.Models;
using Garage_2.Models.ReceiptViewModel;
using Garage_2.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace Garage_2.Models.ViewModels {
    public class MemberViewModel {



        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FullName { get;  set; }
        public string Phone { get; set; }
        public string SocialSecurityNumber { get; set; }
        public string Email { get; set; }
        public string Street { get; set; }
        public string ZIP { get; set; }
        public string Adress => $"{Street}, {ZIP}";
        public string Avatar { get; set; }
        public ICollection<ParkedVehicle> ParkedVehicles { get; set; }
    }
}
