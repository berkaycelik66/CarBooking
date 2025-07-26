using CarBooking.Application.Features.Mediator.Queries.CarDescriptionQueries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace CarBooking.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarDescriptionsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CarDescriptionsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("GetCarDescriptionByCarId/{id}")]
        public async Task<IActionResult> GetCarDescriptionByCarId(int id)
        {
            var value = await _mediator.Send(new GetCarDescriptionByCarIdQuery(id));
            return Ok(value);
        }
    }
}
