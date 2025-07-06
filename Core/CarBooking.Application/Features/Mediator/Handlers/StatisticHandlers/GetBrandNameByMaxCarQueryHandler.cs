using CarBooking.Application.Features.Mediator.Queries.StatisticQueries;
using CarBooking.Application.Features.Mediator.Results.StatisticResults;
using CarBooking.Application.Interfaces.StatisticInterfaces;
using MediatR;

namespace CarBooking.Application.Features.Mediator.Handlers.StatisticHandlers
{
    public class GetBrandNameByMaxCarQueryHandler : IRequestHandler<GetBrandNameByMaxCarQuery, GetBrandNameByMaxCarQueryResult>
    {
        private readonly IStatisticRepository _statisticRepository;

        public GetBrandNameByMaxCarQueryHandler(IStatisticRepository statisticRepository)
        {
            _statisticRepository = statisticRepository;
        }

        public async Task<GetBrandNameByMaxCarQueryResult> Handle(GetBrandNameByMaxCarQuery request, CancellationToken cancellationToken)
        {
            var value = await _statisticRepository.GetBrandNameByMaxCar();
            return new GetBrandNameByMaxCarQueryResult
            {
                BrandNameByMaxCar = value
            };
        }
    }
}
