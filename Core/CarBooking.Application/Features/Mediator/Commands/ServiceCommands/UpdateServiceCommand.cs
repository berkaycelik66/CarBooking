﻿using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBooking.Application.Features.Mediator.Commands.ServiceCommands
{
    public class UpdateServiceCommand: IRequest
    {
        public int ServiceID { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
        public string? IconUrl { get; set; }
    }
}
