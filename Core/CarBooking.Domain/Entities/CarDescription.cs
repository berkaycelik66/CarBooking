﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBooking.Domain.Entities
{
    public class CarDescription
    {
        public int CarDescriptionID { get; set; }
        public int CarID { get; set; }
        public string? Details { get; set; }

        public Car? Car { get; set; }
    }
}
