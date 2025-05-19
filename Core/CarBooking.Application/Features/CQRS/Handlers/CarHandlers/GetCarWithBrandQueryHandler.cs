using CarBooking.Application.Features.CQRS.Results.CarResults;
using CarBooking.Application.Interfaces;
using CarBooking.Application.Interfaces.CarInterfaces;
using CarBooking.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBooking.Application.Features.CQRS.Handlers.CarHandlers
{
    public class GetCarWithBrandQueryHandler
    {
        private readonly ICarRepository _carRepository;

        public GetCarWithBrandQueryHandler( ICarRepository carRepository)
        {
            _carRepository = carRepository;
        }

        public async Task<List<GetCarWithBrandQueryResult>> Handle()
        {
            var values = await _carRepository.GetCarListWithBrands();
            return values.Select(x => new GetCarWithBrandQueryResult
            {
                CarID = x.CarID,
                BrandID = x.BrandID,
                BrandName = x.Brand!.Name,
                Model = x.Model,
                CoverImageUrl = x.CoverImageUrl,
                Mileage = x.Mileage,
                Transmission = x.Transmission,
                Seat = x.Seat,
                Luggage = x.Luggage,
                FuelType = x.FuelType,
                BigImageUrl = x.BigImageUrl,
            }).ToList();
        }
    }
}
