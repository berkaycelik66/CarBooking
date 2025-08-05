using CarBooking.Application.Features.Mediator.Commands.AppUserCommands;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarBooking.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegisterController : ControllerBase
    {
        private readonly IMediator _mediator;

        public RegisterController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> CreateUser([FromBody] CreateAppUserCommand command)
        {
            await _mediator.Send(command);
            return Ok("Kullanıcı kaydı oluşturuldu.");
        }
    }
}
