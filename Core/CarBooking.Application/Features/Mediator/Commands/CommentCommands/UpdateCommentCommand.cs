using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBooking.Application.Features.Mediator.Commands.CommentCommands
{
    public class UpdateCommentCommand : IRequest
    {
        public int CommentID { get; set; }
        public string? Name { get; set; }
        public string? Mail { get; set; }
        public string? Content { get; set; }
        public DateTime CreatedDate { get; set; }
        public int BlogID { get; set; }
    }
}
