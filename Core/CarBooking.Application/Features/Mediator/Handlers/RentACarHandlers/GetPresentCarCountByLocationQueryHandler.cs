using CarBooking.Application.Features.CQRS.Results.CarResults;
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
    public class GetPresentCarCountByLocationQueryHandler : IRequestHandler<GetPresentCarCountByLocationQuery, List<GetPresentCarCountByLocationQueryResult>>
    {
        private readonly IRentACarRepository _rentACarRepository;

        public GetPresentCarCountByLocationQueryHandler(IRentACarRepository rentACarRepository)
        {
            _rentACarRepository = rentACarRepository;
        }

        public async Task<List<GetPresentCarCountByLocationQueryResult>> Handle(GetPresentCarCountByLocationQuery request, CancellationToken cancellationToken)
        {
            var values = await _rentACarRepository.GetPresentCarCountByLocation();
            return values.GroupBy(x => new {  LocationName = x.Location?.Name })
                .Select(g => new GetPresentCarCountByLocationQueryResult
                {
                    LocationName = g.Key.LocationName,
                    PresentCarCount = g.Where(x => x.IsAvailable == true).Count()
                }).ToList();
        }
    }
}
