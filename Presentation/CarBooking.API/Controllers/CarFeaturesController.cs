using CarBooking.Application.Features.Mediator.Commands.CarFeatureCommands;
using CarBooking.Application.Features.Mediator.Commands.TagCloudCommands;
using CarBooking.Application.Features.Mediator.Queries.CarFeatureQueries;
using CarBooking.Application.Features.Mediator.Queries.TagCloudQueries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarBooking.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarFeaturesController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CarFeaturesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("GetCarFeaturesByCarId/{id}")]
        public async Task<IActionResult> GetCarFeaturesByCarIdList(int id)
        {
            var values = await _mediator.Send(new GetCarFeatureByCarIdQuery(id));
            return Ok(values);
        }

        [HttpPatch("ChangeCarFeaturePresentToFalse/{id}")]
        public async Task<IActionResult> ChangeCarFeaturePresentToFalse(int id)
        {
            await _mediator.Send(new UpdateCarFeaturePresentChangeToFalseCommand(id));
            return Ok("Feature Bilgisi False Olarak Güncellendi");
        }

        [HttpPatch("ChangeCarFeaturePresentToTrue/{id}")]
        public async Task<IActionResult> ChangeCarFeaturePresentToTrue(int id)
        {
            await _mediator.Send(new UpdateCarFeaturePresentChangeToTrueCommand(id));
            return Ok("Feature Bilgisi True Olarak Güncellendi");
        }
    }
}
