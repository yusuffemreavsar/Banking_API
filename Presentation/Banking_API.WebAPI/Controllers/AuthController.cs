﻿using Banking_API.Application.Features.Auth.Commands;
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
            
            if (registerCommandRequest._RegisterRequestDto == null)
            {
                return BadRequest("RegisterRequestDto is null.");
            }
            var response= await _mediator.Send(registerCommandRequest);
            return Ok(response);
        }
    }
}
