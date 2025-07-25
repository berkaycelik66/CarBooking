﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBooking.Application.Features.CQRS.Commands.ContactCommands
{
    public class CreateContactCommand
    {
        public string? Name { get; set; }
        public string? Mail { get; set; }
        public string? Subject { get; set; }
        public string? Content { get; set; }
        public DateTime Date { get; set; }
    }
}
