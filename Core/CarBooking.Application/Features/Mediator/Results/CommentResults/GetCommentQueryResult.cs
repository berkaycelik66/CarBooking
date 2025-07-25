﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBooking.Application.Features.Mediator.Results.CommentResults
{
    public class GetCommentQueryResult
    {
        public int CommentID { get; set; }
        public string? Name { get; set; }
        public string? Mail { get; set; }
        public string? Content { get; set; }
        public DateTime CreatedDate { get; set; }
        public int BlogID { get; set; }
    }
}
