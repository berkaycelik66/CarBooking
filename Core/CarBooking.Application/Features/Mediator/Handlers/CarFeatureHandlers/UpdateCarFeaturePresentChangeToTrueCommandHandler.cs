using CarBooking.Application.Features.Mediator.Commands.CarFeatureCommands;
using CarBooking.Application.Interfaces.CarFeatureInterfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBooking.Application.Features.Mediator.Handlers.CarFeatureHandlers
{
    public class UpdateCarFeaturePresentChangeToTrueCommandHandler : IRequestHandler<UpdateCarFeaturePresentChangeToTrueCommand>
    {
        private readonly ICarFeatureRepository _carFeatureRepository;

        public UpdateCarFeaturePresentChangeToTrueCommandHandler(ICarFeatureRepository carFeatureRepository)
        {
            _carFeatureRepository = carFeatureRepository;
        }

        public async Task Handle(UpdateCarFeaturePresentChangeToTrueCommand request, CancellationToken cancellationToken)
        {
            await _carFeatureRepository.ChangeCarFeaturePresentToTrue(request.Id);
        }
    }
}
