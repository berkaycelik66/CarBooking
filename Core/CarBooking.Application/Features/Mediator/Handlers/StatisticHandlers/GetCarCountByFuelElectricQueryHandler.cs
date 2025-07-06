using CarBooking.Application.Features.Mediator.Queries.StatisticQueries;
using CarBooking.Application.Features.Mediator.Results.StatisticResults;
using CarBooking.Application.Interfaces.StatisticInterfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBooking.Application.Features.Mediator.Handlers.StatisticHandlers
{
    public class GetCarCountByFuelElectricQueryHandler : IRequestHandler<GetCarCountByFuelElectricQuery, GetCarCountByFuelElectricQueryResult>
    {
        private readonly IStatisticRepository _statisticRepository;

        public GetCarCountByFuelElectricQueryHandler(IStatisticRepository statisticRepository)
        {
            _statisticRepository = statisticRepository;
        }

        public async Task<GetCarCountByFuelElectricQueryResult> Handle(GetCarCountByFuelElectricQuery request, CancellationToken cancellationToken)
        {
            var value = await _statisticRepository.GetCarCountByFuelElectric();
            return new GetCarCountByFuelElectricQueryResult
            {
                CarCountByFuelElectric = value
            };
        }
    }
}
