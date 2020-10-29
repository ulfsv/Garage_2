using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Garage_2.Models;


namespace Garage_2.Models.DetailsViewModels {
    public class DetailsViewModel {
        public int Id { get; set; }

        [Required]
        [Display(Name = "Type")]
        public String VehicleTypeVehicType { get; set; }

        [Required]
        [Range(0, 4, ErrorMessage = "0 to 4 wheels allowed!")]
        [Display(Name = "Wheels No")]
        public int WheelsNumber { get; set; }
        [Required]
        public string Color { get; set; }
        [Required]
        public string Model { get; set; }
        [Required]
        public string Brand { get; set; }
        public string MemberFullName { get; set; }
        public string MemberAdress { get; set; }
        public string MemberAvatar { get; set; }
        public string RegisterNumber { get; set; }
        public string MemberEmail { get; set; }

        public DateTime ParkedDateTime { get; set; }
        public ICollection<ParkedVehicle> ParkedVehicles { get; set; }
        public  DetailsViewModel() {
            this.ParkedVehicles = ParkedVehicles;
        }





    }
}
