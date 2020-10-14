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
        public VehicleTypeEnum VehicleType { get; set; }
        [Required]
        public string RegisterNumber { get; set; }
        [Required]
        public string Color { get; set; }
        [Required]
        public string Model { get; set; }
        [Required]
        public string Brand { get; set; }
        [Required]
        public int WheelsNumber { get; set; }
        [Required]
        public DateTime ChechInDateTime { get; set; }
        [Required]
        public DateTime CheckOutDateTime { get; set; }
    }

}
