using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBooking.Application.Features.CQRS.Results.CarResults
{
    public class GetCarCountByBrandQueryResult
    {
        public string? BrandName { get; set; }
        public int CarCount { get; set; }
    }
}
