using System.Collections.Generic;

namespace Garage_2.Models
{
    public class VehicleType
    {
        // Primary key
        public int Id { get; set; }
        
        //TODO size

        public string VehicType { get; set; }

        // Navigation property
        public ICollection<ParkedVehicle> ParkedVehicles { get; set; }

    }
}
