﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBooking.Application.Features.Mediator.Results.CarDescriptionResults
{
    public class GetCarDescriptionByCarIdQueryResult
    {
        public int CarDescriptionID { get; set; }
        public int CarID { get; set; }
        public string? Details { get; set; }
    }
}
