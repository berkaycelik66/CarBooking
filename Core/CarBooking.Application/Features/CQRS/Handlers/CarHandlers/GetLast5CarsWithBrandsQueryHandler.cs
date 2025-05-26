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
    public class GetLast5CarsWithBrandsQueryHandler
    {
        private readonly ICarRepository _carRepository;

        public GetLast5CarsWithBrandsQueryHandler(ICarRepository carRepository)
        {
            _carRepository = carRepository;
        }

        public async Task<List<GetLast5CarsWithBrandsQueryResult>> Handle()
        {
            var values = await _carRepository.GetLast5CarsWithBrands();
            return values.Select(x => new GetLast5CarsWithBrandsQueryResult 
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
