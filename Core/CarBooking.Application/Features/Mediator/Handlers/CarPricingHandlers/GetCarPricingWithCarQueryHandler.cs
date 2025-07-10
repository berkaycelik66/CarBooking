using CarBooking.Application.Features.Mediator.Queries.CarPricingQueries;
using CarBooking.Application.Features.Mediator.Results.CarPricingResults;
using CarBooking.Application.Interfaces.CarPricingInterfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBooking.Application.Features.Mediator.Handlers.CarPricingHandlers
{
    public class GetCarPricingWithCarQueryHandler : IRequestHandler<GetCarPricingWithCarQuery, List<GetCarPricingWithCarQueryResult>>
    {
        private readonly ICarPricingRepository _carPricingRepository;

        public GetCarPricingWithCarQueryHandler(ICarPricingRepository carPricingRepository)
        {
            _carPricingRepository = carPricingRepository;
        }

        public async Task<List<GetCarPricingWithCarQueryResult>> Handle(GetCarPricingWithCarQuery request, CancellationToken cancellationToken)
        {
            var values = await _carPricingRepository.GetCarPricingWithCars();
            return values.Select(x => new GetCarPricingWithCarQueryResult{
                CarPricingID = x.CarPricingID,
                CarID = x.CarID,
                Brand = x.Car!.Brand!.Name,
                Model = x.Car.Model,
                Amount = x.Price,
                CoverImageUrl = x.Car.CoverImageUrl,
            }).ToList();
        }
    }
}
