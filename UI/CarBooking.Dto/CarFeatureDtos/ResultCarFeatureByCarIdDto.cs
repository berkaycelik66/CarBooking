﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBooking.Dto.CarFeatureDtos
{
    public class ResultCarFeatureByCarIdDto
    {
        public int CarFeatureID { get; set; }
        public int CarID { get; set; }
        public int FeatureID { get; set; }
        public string? FeatureName { get; set; }
        public bool IsPresent { get; set; }
    }
}
