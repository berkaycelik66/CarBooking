﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBooking.Application.Features.Mediator.Results.ReviewResults
{
    public class GetReviewByCarIdQueryResult
    {
        public int ReviewID { get; set; }
        public string? CustomerName { get; set; }
        public string? Comment { get; set; }
        public int RatingValue { get; set; }
        public DateTime ReviewDate { get; set; }
        public int CarID { get; set; }
    }
}
