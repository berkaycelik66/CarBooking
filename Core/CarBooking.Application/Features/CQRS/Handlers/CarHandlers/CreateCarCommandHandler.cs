using CarBooking.Application.Features.CQRS.Commands.BrandCommands;
using CarBooking.Application.Features.CQRS.Commands.CarCommands;
using CarBooking.Application.Interfaces;
using CarBooking.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBooking.Application.Features.CQRS.Handlers.CarHandlers
{
    public class CreateCarCommandHandler
    {
        private readonly IRepository<Car> _repository;

        public CreateCarCommandHandler(IRepository<Car> repository)
        {
            _repository = repository;
        }

        public async Task Handle(CreateCarCommand command)
        {
            await _repository.CreateAsync(new Car
            {
               BrandID = command.BrandID,
               Model = command.Model,
               CoverImageUrl = command.CoverImageUrl,
               Mileage = command.Mileage,
               Transmission = command.Transmission,
               Seat = command.Seat,
               Luggage = command.Luggage,
               FuelType = command.FuelType,
               BigImageUrl = command.BigImageUrl,
            });
        }
    }
}
