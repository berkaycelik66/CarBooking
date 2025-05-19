using CarBooking.Application.Features.CQRS.Queries.BrandQueries;
using CarBooking.Application.Features.CQRS.Queries.CarQueries;
using CarBooking.Application.Features.CQRS.Results.BrandResults;
using CarBooking.Application.Features.CQRS.Results.CarResults;
using CarBooking.Application.Interfaces;
using CarBooking.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBooking.Application.Features.CQRS.Handlers.CarHandlers
{
    public class GetCarByIdQueryHandler
    {
        private readonly IRepository<Car> _repository;

        public GetCarByIdQueryHandler(IRepository<Car> repository)
        {
            _repository = repository;
        }

        public async Task<GetCarByIdQueryResult> Handle(GetCarByIdQuery query)
        {
            var value = await _repository.GetByIdAsync(query.Id);
            return new GetCarByIdQueryResult
            {
                CarID = value.CarID,
                BrandID = value.BrandID,
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
