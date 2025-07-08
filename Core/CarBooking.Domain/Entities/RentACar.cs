using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBooking.Domain.Entities
{
    public class RentACar
    {
        public int RentACarID { get; set; }

        [ForeignKey("Location")]
        public int PickUpLocationID { get; set; }
        public int CarID { get; set; }
        public bool IsAvailable { get; set; }

        public Location? Location { get; set; }
        public Car? Car { get; set; }
    }
}
