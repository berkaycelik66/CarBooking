using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBooking.Dto.RentACarDtos
{
    public class ResultPresentCarCountByLocationDto
    {
        public string? LocationName { get; set; }
        public int PresentCarCount { get; set; }
    }
}
