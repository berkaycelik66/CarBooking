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
    public class GetAverageRentPriceForMonthlyQueryHandler : IRequestHandler<GetAverageRentPriceForMonthlyQuery, GetAverageRentPriceForMonthlyQueryResult>
    {
        private readonly IStatisticRepository _statisticRepository;

        public GetAverageRentPriceForMonthlyQueryHandler(IStatisticRepository statisticRepository)
        {
            _statisticRepository = statisticRepository;
        }

        public async Task<GetAverageRentPriceForMonthlyQueryResult> Handle(GetAverageRentPriceForMonthlyQuery request, CancellationToken cancellationToken)
        {
            var value = await _statisticRepository.GetAverageRentPriceForMonthly();
            return new GetAverageRentPriceForMonthlyQueryResult
            {
                AverageRentPriceForMonthly = value
            };
        }
    }
}
