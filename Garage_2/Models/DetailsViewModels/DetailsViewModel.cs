using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Garage_2.Models.DetailsViewModel {
    public class DetailsViewModel {
        public int Id { get; set; }

        [Required]
        [Display(Name = "Type")]
        public VehicleTypeEnum VehicleType { get; set; }

        [Required]
        [Display(Name = "Wheels No")]
        public int WheelsNumber { get; set; }
        [Required]
        public string Color { get; set; }
        [Required]
        public string Model { get; set; }
        [Required]
        public string Brand { get; set; }





    }
}
