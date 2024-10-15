using Banking_API.Application.Features.Auth.Login.Rules;
using Banking_API.Application.Services;
using Banking_API.Domain.Entities.Identity;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace Banking_API.Application.Features.Auth.Login.Commands
{
    public class LoginCommandHandler : IRequestHandler<LoginCommandRequest, LoginCommandResponse>
    {
        private readonly IAuthService _authService;
        private readonly UserManager<AppUser> _userManager;
        private readonly LoginBusinessRules _loginBusinessRules;
        public LoginCommandHandler(IAuthService authService, UserManager<AppUser> userManager, LoginBusinessRules loginBusinessRules)
        {
            _authService = authService;
            _userManager = userManager;
            _loginBusinessRules = loginBusinessRules;
        }

        public async Task<LoginCommandResponse> Handle(LoginCommandRequest request, CancellationToken cancellationToken)
        {
            var user = await _userManager.FindByEmailAsync(request.LoginRequestDto.Email);
            await _loginBusinessRules.UserShouldBeExists(user);
            await _loginBusinessRules.CheckPasswordAsync(user, request.LoginRequestDto.Password);
            var token = await _authService.Login(user);

            return new LoginCommandResponse() { Token = token };
        }
    }
}
