﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBooking.Dto.TagCloudDtos
{
    public class ResultTagCloudByBlogIdDto
    {
        public int TagCloudID { get; set; }
        public string? Title { get; set; }
        public int BlogID { get; set; }
    }
}
