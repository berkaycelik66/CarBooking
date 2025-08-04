using CarBooking.Application.Features.Mediator.Queries.AppUserQueries;
using CarBooking.Application.Tools;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarBooking.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly IMediator _mediator;

        public LoginController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> Login([FromBody] GetCheckAppUserQuery query)
        {
            var value = await _mediator.Send(query);
            if(value.IsExist)
            {
                return Created("", JwtTokenGenerator.GenerateToken(value));
            }

            return BadRequest("Kullanıcı adı veya şifre hatalı");
        }
    }
}
