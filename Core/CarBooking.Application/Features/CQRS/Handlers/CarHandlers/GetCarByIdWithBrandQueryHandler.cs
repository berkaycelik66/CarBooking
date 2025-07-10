using CarBooking.Application.Features.CQRS.Queries.CarQueries;
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
    public class GetCarByIdWithBrandQueryHandler
    {
        private readonly ICarRepository _carRepository;

        public GetCarByIdWithBrandQueryHandler(ICarRepository carRepository)
        {
            _carRepository = carRepository;
        }

        public async Task<GetCarByIdWithBrandQueryResult> Handle(GetCarByIdWithBrandQuery query)
        {
            var value = await _carRepository.GetCarByIdWithBrand(query.Id);
            return new GetCarByIdWithBrandQueryResult
            {
                CarID = value!.CarID,
                BrandID = value.BrandID,
                BrandName = value.Brand!.Name,
                Model = value.Model,
                CoverImageUrl = value.CoverImageUrl,
            };
        }
    }
}
