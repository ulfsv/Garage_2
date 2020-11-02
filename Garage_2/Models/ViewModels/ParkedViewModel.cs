using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Garage_2.Models;

namespace Garage_2.Models.ViewModels
{
    public class ParkedViewModel
    {
        [Required]
        [Display(Name = "Register No")]
        public string RegisterNumber { get; set; }

        [Required]
        [Display(Name = "Parked time")]

        public DateTime ParkedDateTime { get; set; }

        [Required]
        public int Id { get; set; }

        [Required]
        [Display(Name = "Type")]
        public string VehicleTypeVehicType { get; set; }  // VehicleType VehicType enligt konvention
        [Display(Name = "Client Name")]

        public string MemberFullName { get; set; }
        public string MemberAvatar { get; set; }
        public string MemberAdress { get; set; }
        public string MemberEmail { get; set; }
        public string MemberSocialSecurityNumber { get; set; }
    }
}
