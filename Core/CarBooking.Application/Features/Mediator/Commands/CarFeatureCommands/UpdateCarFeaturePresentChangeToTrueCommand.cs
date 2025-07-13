using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBooking.Application.Features.Mediator.Commands.CarFeatureCommands
{
    public class UpdateCarFeaturePresentChangeToTrueCommand : IRequest
    {
        public int Id { get; set; }

        public UpdateCarFeaturePresentChangeToTrueCommand(int id)
        {
            Id = id;
        }
    }
}
