using CarBooking.Application.Features.Mediator.Queries.StatisticQueries;
using CarBooking.Application.Features.Mediator.Results.StatisticResults;
using CarBooking.Application.Interfaces.CarInterfaces;
using CarBooking.Application.Interfaces.StatisticInterfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBooking.Application.Features.Mediator.Handlers.StatisticHandlers
{
    public class GetCarCountQueryHandler : IRequestHandler<GetCarCountQuery, GetCarCountQueryResult>
    {
        private readonly IStatisticRepository _statisticRepository;

        public GetCarCountQueryHandler(IStatisticRepository statisticRepository)
        {
            _statisticRepository = statisticRepository;
        }

        public async Task<GetCarCountQueryResult> Handle(GetCarCountQuery request, CancellationToken cancellationToken)
        {
            var value = await _statisticRepository.GetCarCount();
            return new GetCarCountQueryResult
            {
                CarCount = value
            };
        }
    }
}
