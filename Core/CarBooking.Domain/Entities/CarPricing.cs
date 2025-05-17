﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBooking.Domain.Entities
{
    public class CarPricing
    {
        public int CarPricingID { get; set; }
        public int CarID { get; set; }
        public int PricingID { get; set; }
        public decimal Price { get; set; }

        public Car? Car { get; set; }
        public Pricing? Pricing { get; set; }
    }
}
