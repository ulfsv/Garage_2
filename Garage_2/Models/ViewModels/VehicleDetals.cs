﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Garage_2.Models.ViewModels {
    public class VehicleDetals {
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
        public string VehicleType { get; set; }

    }
}
