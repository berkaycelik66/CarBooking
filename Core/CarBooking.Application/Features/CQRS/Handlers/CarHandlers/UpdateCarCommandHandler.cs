using CarBooking.Application.Features.CQRS.Commands.BrandCommands;
using CarBooking.Application.Features.CQRS.Commands.CarCommands;
using CarBooking.Application.Interfaces;
using CarBooking.Domain.Entities;
using Microsoft.VisualBasic.FileIO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBooking.Application.Features.CQRS.Handlers.CarHandlers
{
    public class UpdateCarCommandHandler
    {
        private readonly IRepository<Car> _repository;

        public UpdateCarCommandHandler(IRepository<Car> repository)
        {
            _repository = repository;
        }

        public async Task Handle(UpdateCarCommand command)
        {
            var value = await _repository.GetByIdAsync(command.CarID);
            value.BrandID = command.BrandID;
            value.Model = command.Model;
            value.CoverImageUrl = command.CoverImageUrl;
            value.Mileage = command.Mileage;
            value.Transmission = command.Transmission;
            value.Seat = command.Seat;
            value.Luggage = command.Luggage;
            value.FuelType = command.FuelType;
            value.BigImageUrl = command.BigImageUrl;
            await _repository.UpdateAsync(value);
        }
    }
}
