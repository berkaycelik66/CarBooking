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
    public class GetAverageRentPriceForWeeklyQueryHandler : IRequestHandler<GetAverageRentPriceForWeeklyQuery, GetAverageRentPriceForWeeklyQueryResult>
    {
        private readonly IStatisticRepository _statisticRepository;

        public GetAverageRentPriceForWeeklyQueryHandler(IStatisticRepository statisticRepository)
        {
            _statisticRepository = statisticRepository;
        }

        public async Task<GetAverageRentPriceForWeeklyQueryResult> Handle(GetAverageRentPriceForWeeklyQuery request, CancellationToken cancellationToken)
        {
            var value = await _statisticRepository.GetAverageRentPriceForWeekly();
            return new GetAverageRentPriceForWeeklyQueryResult
            {
                AverageRentPriceForWeekly = value
            };
        }
    }
}
