using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Garage_2.Models.ReceiptViewModel {
    public class Receipt {
        [Display(Name = "Price per hour:")]
        [DataType(DataType.Currency)]
        public int PricePerHour { get; set; }

        [Display(Name = "Registration number:")]
        public string RegNr { get; set; }

        [Display(Name = "Vehicle parked at time")]
        public DateTime ParkingTime { get; set; }
        

    }
}
