using Banking_API.Application.Features.Auth.Login.Commands;
using Banking_API.Application.Features.Auth.Register.Commands;
using Banking_API.Domain.Entities.Identity;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Banking_API.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        readonly IMediator _mediator;

        public AuthController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("Register")]
        public async Task<IActionResult> Register([FromBody]RegisterCommandRequest registerCommandRequest)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (registerCommandRequest._RegisterRequestDto == null)
            {
                return BadRequest("RegisterRequestDto is null.");
            }
            var response= await _mediator.Send(registerCommandRequest);
            return Ok(response);
        }

        [HttpPost("Login")]
        public async Task<IActionResult> Login([FromBody] LoginCommandRequest loginCommandRequest)
        {
           

            if (loginCommandRequest.LoginRequestDto ==null)
            {
                return BadRequest("LoginRequestDto is null.");
            }
            var response = await _mediator.Send(loginCommandRequest);
         
            return Ok(response);
        }
    }
}
