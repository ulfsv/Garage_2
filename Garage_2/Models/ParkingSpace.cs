using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Garage_2.Models
{
    public class ParkingSpace
    {
        public int Id { get; set; }

        public ParkedVehicle parkedVehicle { get; set; }


        // Foreign keys
        public int ParkedVehicleId { get; set; }


        // Navigation properties
        public int ParkedVehicle { get; set; }
    }
}
