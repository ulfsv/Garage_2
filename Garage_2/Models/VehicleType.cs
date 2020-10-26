using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Garage_2.Models
{
    public class VehicleType
    {
        // Primary key
        public int Id { get; set; }
        public string VehicType { get; set; }

        // Navigation property
        public ICollection<ParkedVehicle> ParkedVehicles { get; set; }
    }
}
