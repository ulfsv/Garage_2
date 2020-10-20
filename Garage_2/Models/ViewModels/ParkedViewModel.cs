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
        private DateTime parkedDateTime;

        [Required]
        [Display(Name = "Type")]
        public VehicleTypeEnum VehicleType { get; set; }

        [Required]
        [Display(Name = "Register No")]
        public string RegisterNumber { get; set; }

        [Required]
        [Display(Name = "Parked time")]

        public DateTime ParkedDateTime { get; set; }
        
        
        [Required]
        public int Id { get; set; }
    }
}
