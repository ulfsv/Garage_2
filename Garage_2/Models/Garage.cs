using System.Collections.Generic;

namespace Garage_2.Models
{
    public class Garage
    {
        // Primary key
        public int Id { get; set; }

        public int ParkingSpaceNum { get; set; }

        // Navigation property
        //public ICollection<ParkedVehicle> ParkedVehicles { get; set; }

    }
}
