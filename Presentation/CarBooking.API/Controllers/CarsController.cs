using CarBooking.Application.Features.CQRS.Commands.CarCommands;
using CarBooking.Application.Features.CQRS.Handlers.CarHandlers;
using CarBooking.Application.Features.CQRS.Queries.CarQueries;
using CarBooking.Application.Features.Mediator.Queries.StatisticQueries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarBooking.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarsController : ControllerBase
    {
        private readonly CreateCarCommandHandler _createCarCommandHandler;
        private readonly GetCarByIdQueryHandler _getCarByIdQueryHandler;
        private readonly GetCarQueryHandler _getCarQueryHandler;
        private readonly RemoveCarCommandHandler _removeCarCommandHandler;
        private readonly UpdateCarCommandHandler _updateCarCommandHandler;
        private readonly GetCarWithBrandQueryHandler _getCarWithBrandQueryHandler;
        private readonly GetLast5CarsWithBrandsQueryHandler _getLast5CarsWithBrandsQueryHandler;
        private readonly GetCarByIdWithBrandQueryHandler _getCarByIdWithBrandQueryHandler;
        private readonly IMediator _mediator;

        public CarsController(CreateCarCommandHandler createCarCommandHandler, GetCarByIdQueryHandler getCarByIdQueryHandler, GetCarQueryHandler getCarQueryHandler, RemoveCarCommandHandler removeCarCommandHandler, UpdateCarCommandHandler updateCarCommandHandler, GetCarWithBrandQueryHandler getCarWithBrandQueryHandler, GetLast5CarsWithBrandsQueryHandler getLast5CarsWithBrandsQueryHandler, IMediator mediator, GetCarByIdWithBrandQueryHandler getCarByIdWithBrandQueryHandler)
        {
            _createCarCommandHandler = createCarCommandHandler;
            _getCarByIdQueryHandler = getCarByIdQueryHandler;
            _getCarQueryHandler = getCarQueryHandler;
            _removeCarCommandHandler = removeCarCommandHandler;
            _updateCarCommandHandler = updateCarCommandHandler;
            _getCarWithBrandQueryHandler = getCarWithBrandQueryHandler;
            _getLast5CarsWithBrandsQueryHandler = getLast5CarsWithBrandsQueryHandler;
            _mediator = mediator;
            _getCarByIdWithBrandQueryHandler = getCarByIdWithBrandQueryHandler;
        }

        [HttpGet]
        public async Task<IActionResult> CarList()
        {
            var values = await _getCarQueryHandler.Handle();
            return Ok(values);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCar(int id)
        {
            var value = await _getCarByIdQueryHandler.Handle(new GetCarByIdQuery(id));
            return Ok(value);
        }

        [HttpPost]
        public async Task<IActionResult> CreateCar(CreateCarCommand command)
        {
            await _createCarCommandHandler.Handle(command);
            return Ok("Yeni Araba Bilgisi Eklendi");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> RemoveCar(int id)
        {
            await _removeCarCommandHandler.Handle(new RemoveCarCommand(id));
            return Ok("Araba Bilgisi Silindi");
        }

        [HttpPut]
        public async Task<IActionResult> UpdateCar(UpdateCarCommand command)
        {
            await _updateCarCommandHandler.Handle(command);
            return Ok("Araba Bilgisi Güncellendi");
        }

        [HttpGet("GetCarWithBrand")]
        public async Task<IActionResult> GetCarWithBrand()
        {
            var values = await _getCarWithBrandQueryHandler.Handle();
            return Ok(values);
        }

        [HttpGet("GetLast5CarsWithBrands")]
        public async Task<IActionResult> GetLast5CarsWithBrands()
        {
            var values = await _getLast5CarsWithBrandsQueryHandler.Handle();
            return Ok(values);
        }

        [HttpGet("GetCarByIdWithBrand/{id}")]
        public async Task<IActionResult> GetCarByIdWithBrand(int id)
        {
            var values = await _getCarByIdWithBrandQueryHandler.Handle(new GetCarByIdWithBrandQuery(id));
            return Ok(values);
        }
    }
}
