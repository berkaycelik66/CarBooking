using CarBooking.Application.Features.CQRS.Results.CarResults;
using CarBooking.Application.Features.Mediator.Results.CarPricingResults;
using CarBooking.Application.Interfaces.CarInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBooking.Application.Features.CQRS.Handlers.CarHandlers
{
    public class GetCarCountByBrandQueryHandler
    {
        private readonly ICarRepository _carRepository;

        public GetCarCountByBrandQueryHandler(ICarRepository carRepository)
        {
            _carRepository = carRepository;
        }

        public async Task<List<GetCarCountByBrandQueryResult>> Handle()
        {
            var values = await _carRepository.GetCarCountByBrand();
            return values.GroupBy(x => new { BrandName = x.Brand?.Name })
                .Select(g => new GetCarCountByBrandQueryResult
                {
                    BrandName = g.Key.BrandName,
                    CarCount = g.Count()
                }).ToList();
        }
    }
}
