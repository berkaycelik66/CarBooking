using CarBooking.Application.Features.Mediator.Queries.RentACarQueries;
using CarBooking.Application.Features.Mediator.Results.RentACarResults;
using CarBooking.Application.Interfaces.RentACarInterfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBooking.Application.Features.Mediator.Handlers.RentACarHandlers
{
    public class GetRentACarQueryHandler : IRequestHandler<GetRentACarQuery, List<GetRentACarQueryResult>>
    {
        private readonly IRentACarRepository _rentACarRepository;

        public GetRentACarQueryHandler(IRentACarRepository rentACarRepository)
        {
            _rentACarRepository = rentACarRepository;
        }

        public async Task<List<GetRentACarQueryResult>> Handle(GetRentACarQuery request, CancellationToken cancellationToken)
        {
            var values = await _rentACarRepository.GetByFilterAsync(x => x.PickUpLocationID == request.PickUpLocationID && x.IsAvailable == request.IsAvailable);
            return values.Select(x => new GetRentACarQueryResult
            {
                CarID = x.CarID,
                Brand = x.Car!.Brand!.Name,
                Model = x.Car.Model,
                Amount = x.Car.CarPricings.Where(cp => cp.CarID == x.CarID).Select(cp => cp.Price).FirstOrDefault(),
                CoverImageUrl = x.Car.CoverImageUrl,
            }).ToList();
        }
    }
}
