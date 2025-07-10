using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBooking.Application.Features.CQRS.Results.CarResults
{
    public class GetCarByIdWithBrandQueryResult
    {
        public int CarID { get; set; }
        public int BrandID { get; set; }
        public string? BrandName { get; set; }
        public string? Model { get; set; }
        public string? CoverImageUrl { get; set; }
    }
}
