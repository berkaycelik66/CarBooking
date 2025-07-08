using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBooking.Domain.Entities
{
    public class RentACarProcess
    {
        public int RentACarProcessID { get; set; }
        public int CarID { get; set; }
        [ForeignKey("Location")]
        public int PickUpLocation { get; set; }
        [ForeignKey("Location")]
        public int DropOffLocation { get; set; }
        public DateOnly PickUpDate { get; set; }
        public DateOnly DropOffDate { get; set; }
        public TimeOnly PickUpTime { get; set; }
        public TimeOnly DropOffTime { get; set; }
        public int CustomerID { get; set; }
        public string? PickUpDescription { get; set; }
        public string? DropOffDescription { get; set; }
        public decimal TotalPrice { get; set; }

        public Car? Car { get; set; }
        public Customer? Customer { get; set; }
    }
}
