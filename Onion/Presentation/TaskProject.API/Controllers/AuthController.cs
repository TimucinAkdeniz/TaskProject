using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TaskProject.Application.DTo.User;
using TaskProject.Application.Features.CQRS.Commands.UserCommand;
using TaskProject.Application.Features.CQRS.Handlers.UserHandler;
using TaskProject.Application.Features.CQRS.Queries.UserQueries;
using TaskProject.Application.Tools;

namespace TaskProject.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IMediator _mediator;

        public AuthController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> Login(CheckUserQueryRequest request)
        {
            var result = await _mediator.Send(request);
            if (result.IsExist)
                return Created("", JwtTokenGenerator.GenerateToken(result));
            else
                return BadRequest("Kullanıcı Adı ve ya Şifre Hatalı");
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> Register(RegisterUserCommandRequest request)
        {
            var result = await _mediator.Send(request);
            if (result.Id == 0)
                return BadRequest("Bu Kullanıcı Adı Daha Önce Kullanılmıştır");
            return Created("",result.Id);
        }
    }
}
