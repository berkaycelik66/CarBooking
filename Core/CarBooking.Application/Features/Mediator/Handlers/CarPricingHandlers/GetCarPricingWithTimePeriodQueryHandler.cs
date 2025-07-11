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
    public class GetCarPricingWithTimePeriodQueryHandler : IRequestHandler<GetCarPricingWithTimePeriodQuery, List<GetCarPricingWithTimePeriodQueryResult>>
    {
        private readonly ICarPricingRepository _carPricingRepository;

        public GetCarPricingWithTimePeriodQueryHandler(ICarPricingRepository carPricingRepository)
        {
            _carPricingRepository = carPricingRepository;
        }

        public async Task<List<GetCarPricingWithTimePeriodQueryResult>> Handle(GetCarPricingWithTimePeriodQuery request, CancellationToken cancellationToken)
        {
            var values = await _carPricingRepository.GetCarPricingWithTimePeriod();
            return values.GroupBy(x => new { x.CarID, x.Car!.Model, BrandName = x.Car.Brand!.Name, CoverImageUrl = x.Car.CoverImageUrl })
                .Select(g => new GetCarPricingWithTimePeriodQueryResult
                {
                    CarID = g.Key.CarID,
                    Model = g.Key.Model,
                    BrandName = g.Key.BrandName,
                    CoverImageUrl = g.Key.CoverImageUrl,
                    DailyPrice = g.FirstOrDefault(p => p.PricingID == 2)?.Price ?? 0,
                    WeeklyPrice = g.FirstOrDefault(p => p.PricingID == 3)?.Price ?? 0,
                    MonthlyPrice = g.FirstOrDefault(p => p.PricingID == 6)?.Price ?? 0
                }).ToList();
        }
    }
}
