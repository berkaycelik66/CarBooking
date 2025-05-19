﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBooking.Application.Features.CQRS.Commands.CarCommands
{
    public class UpdateCarCommand
    {
        public int CarID { get; set; }
        public int BrandID { get; set; }
        public string? Model { get; set; }
        public string? CoverImageUrl { get; set; }
        public int Mileage { get; set; }
        public string? Transmission { get; set; }
        public byte Seat { get; set; }
        public byte Luggage { get; set; }
        public string? FuelType { get; set; }
        public string? BigImageUrl { get; set; }
    }
}
