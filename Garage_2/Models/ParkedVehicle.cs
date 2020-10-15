using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;


namespace Garage_2.Models {
    public class ParkedVehicle {
        [Required]
        public int Id { get; set; }
        [Required]

        [Display( Name = "Type")]
        public VehicleTypeEnum VehicleType { get; set; }

      /* [Remote("IsRegisterNumberExist", "ParkedVehicle", AdditionalFields = "Id",
                ErrorMessage = "RegNo is already exists")]*/
        [Required]
        [Display(Name = "Register No")]
        [RegularExpression(@"(\S)+", ErrorMessage = "White space is not allowed.")]
        
        public string RegisterNumber { get; set; }
        [Required]
        public string Color { get; set; }
        [Required]
        public string Model { get; set; }
        [Required]
        public string Brand { get; set; }
        [Required]
        [Display(Name = "Wheels No")]

        public int WheelsNumber { get; set; }
        [Required]
        [Display(Name = "Parked time")]

        public DateTime ParkedDateTime { get; set; }
       
      
    }

}
