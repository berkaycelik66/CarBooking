using CarBooking.Application.Features.Mediator.Queries.RentACarQueries;
using CarBooking.Application.Features.Mediator.Results.RentACarResults;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarBooking.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RentACarsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public RentACarsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("{id}/{available}")]
        public async Task<IActionResult> GetRentACarListByLocation(int id, bool available)
        {
            GetRentACarQuery getRentACarQuery = new GetRentACarQuery
            {
                PickUpLocationID = id,
                IsAvailable = available
            };
            var values = await _mediator.Send(getRentACarQuery);
            return Ok(values);
        }
    }
}
