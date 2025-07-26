using CarBooking.Application.Features.CQRS.Queries.CarQueries;
using CarBooking.Application.Features.CQRS.Results.CarResults;
using CarBooking.Application.Interfaces.CarInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBooking.Application.Features.CQRS.Handlers.CarHandlers
{
    public class GetCarDetailByIdWithBrandQueryHandler
    {
        private readonly ICarRepository _carRepository;

        public GetCarDetailByIdWithBrandQueryHandler(ICarRepository carRepository)
        {
            _carRepository = carRepository;
        }

        public async Task<GetCarDetailByIdWithBrandQueryResult> Handle(GetCarDetailByIdWithBrandQuery query)
        {
            var value = await _carRepository.GetCarByIdWithBrand(query.Id);
            return new GetCarDetailByIdWithBrandQueryResult
            {
                CarID = value!.CarID,
                BrandID = value.BrandID,
                BrandName = value.Brand!.Name,
                Model = value.Model,
                CoverImageUrl = value.CoverImageUrl,
                Mileage = value.Mileage,
                Transmission = value.Transmission,
                Seat = value.Seat,
                Luggage = value.Luggage,
                FuelType = value.FuelType,
                BigImageUrl = value.BigImageUrl,
            };
        }
    }
}
