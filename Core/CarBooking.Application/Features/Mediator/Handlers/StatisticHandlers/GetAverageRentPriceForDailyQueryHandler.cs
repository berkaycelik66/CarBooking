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
    public class GetAverageRentPriceForDailyQueryHandler : IRequestHandler<GetAverageRentPriceForDailyQuery, GetAverageRentPriceForDailyQueryResult>
    {
        private readonly IStatisticRepository _statisticRepository;

        public GetAverageRentPriceForDailyQueryHandler(IStatisticRepository statisticRepository)
        {
            _statisticRepository = statisticRepository;
        }

        public async Task<GetAverageRentPriceForDailyQueryResult> Handle(GetAverageRentPriceForDailyQuery request, CancellationToken cancellationToken)
        {
            var value = await _statisticRepository.GetAverageRentPriceForDaily();
            return new GetAverageRentPriceForDailyQueryResult
            {
                AverageRentPriceForDaily = value
            };
        }
    }
}
