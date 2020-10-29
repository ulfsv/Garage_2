using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;


namespace Garage_2.Models {

    public class ParkedVehicle {
        public int Id { get; set; }
        
        private string registerNumber;

        [Required]
        [Display(Name = "Register No")]
        [RegularExpression(@"^[a-zA-Z]{3}\d{3}$", ErrorMessage = "Wrong format should be ABC123.")]

        public string RegisterNumber {
            get { return registerNumber; }
            set { registerNumber = value.ToUpper(); }
        }

        [Required]
        public string Color { get; set; }
        [Required]
        public string Model { get; set; }
        [Required]
        public string Brand { get; set; }
        [Required]
        [Range(0, 18, ErrorMessage = "0 to 18 wheels allowed!")]
        [Display(Name = "Wheels No")]

        public int WheelsNumber { get; set; }
        [Required]
        [Display(Name = "Parked time")]

        public DateTime ParkedDateTime { get; set; }

        
        // Foreign keys
        public int MemberId { get; set; }

        [Display(Name = "Type")]
        public int VehicleTypeId { get; set; }

        [Display(Name = "Parking lot")]
        public int GarageId { get; set; }

        // Navigation properties
        public Member Member { get; set; }
        public VehicleType VehicleType { get; set; }

        //public Garage Garage { get; set; }

        public ICollection<Garage> Garage { get; set; }
    }
}

    

