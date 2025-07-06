using CarBooking.Application.Features.Mediator.Queries.StatisticQueries;
using CarBooking.Application.Features.Mediator.Results.StatisticResults;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarBooking.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StatisticsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public StatisticsController(IMediator mediator)
        {
            _mediator = mediator;
        }


        [HttpGet("GetCarCount")]
        public async Task<IActionResult> GetCarCount()
        {
            var values = await _mediator.Send(new GetCarCountQuery());
            return Ok(values);
        }

        [HttpGet("GetLocationCount")]
        public async Task<IActionResult> GetLocationCount()
        {
            var values = await _mediator.Send(new GetLocationCountQuery());
            return Ok(values);
        }

        [HttpGet("GetAuthorCount")]
        public async Task<IActionResult> GetAuthorCount()
        {
            var values = await _mediator.Send(new GetAuthorCountQuery());
            return Ok(values);
        }

        [HttpGet("GetBlogCount")]
        public async Task<IActionResult> GetBlogCount()
        {
            var values = await _mediator.Send(new GetBlogCountQuery());
            return Ok(values);
        }

        [HttpGet("GetBrandCount")]
        public async Task<IActionResult> GetBrandCount()
        {
            var values = await _mediator.Send(new GetBrandCountQuery());
            return Ok(values);

        }

        [HttpGet("GetAverageRentPriceForDaily")]
        public async Task<IActionResult> GetAverageRentPriceForDaily()
        {
            var values = await _mediator.Send(new GetAverageRentPriceForDailyQuery());
            return Ok(values);

        }

        [HttpGet("GetAverageRentPriceForWeekly")]
        public async Task<IActionResult> GetAverageRentPriceForWeekly()
        {
            var values = await _mediator.Send(new GetAverageRentPriceForWeeklyQuery());
            return Ok(values);

        }

        [HttpGet("GetAverageRentPriceForMonthly")]
        public async Task<IActionResult> GetAverageRentPriceForMonthly()
        {
            var values = await _mediator.Send(new GetAverageRentPriceForMonthlyQuery());
            return Ok(values);

        }

        [HttpGet("GetCarCountByTransmissionIsAuto")]
        public async Task<IActionResult> GetCarCountByTransmissionIsAuto()
        {
            var values = await _mediator.Send(new GetCarCountByTransmissionIsAutoQuery());
            return Ok(values);
        }

        [HttpGet("GetCarCountByFuelElectric")]
        public async Task<IActionResult> GetCarCountByFuelElectric()
        {
            var values = await _mediator.Send(new GetCarCountByFuelElectricQuery());
            return Ok(values);
        }

        [HttpGet("GetBrandNameByMaxCar")]
        public async Task<IActionResult> GetBrandNameByMaxCar()
        {
            var values = await _mediator.Send(new GetBrandNameByMaxCarQuery());
            return Ok(values);
        }

        [HttpGet("GetBlogTitleByMaxBlogComment")]
        public async Task<IActionResult> GetBlogTitleByMaxBlogComment()
        {
            var values = await _mediator.Send(new GetBlogTitleByMaxBlogCommentQuery());
            return Ok(values);
        }

        [HttpGet("GetCarBrandAndModelByRentPriceDailyMax")]
        public async Task<IActionResult> GetCarBrandAndModelByRentPriceDailyMax()
        {
            var values = await _mediator.Send(new GetCarBrandAndModelByRentPriceDailyMaxQuery());
            return Ok(values);
        }

        [HttpGet("GetCarBrandAndModelByRentPriceDailyMin")]
        public async Task<IActionResult> GetCarBrandAndModelByRentPriceDailyMin()
        {
            var values = await _mediator.Send(new GetCarBrandAndModelByRentPriceDailyMinQuery());
            return Ok(values);
        }
    }
}
