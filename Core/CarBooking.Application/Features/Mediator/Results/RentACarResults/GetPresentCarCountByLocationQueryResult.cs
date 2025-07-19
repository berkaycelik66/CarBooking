using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBooking.Application.Features.Mediator.Results.RentACarResults
{
    public class GetPresentCarCountByLocationQueryResult
    {
        public string? LocationName { get; set; }
        public int PresentCarCount { get; set; }
    }
}
