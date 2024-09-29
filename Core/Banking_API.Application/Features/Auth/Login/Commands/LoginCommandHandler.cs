using Banking_API.Application.Services;
using MediatR;

namespace Banking_API.Application.Features.Auth.Login.Commands
{
    public class LoginCommandHandler : IRequestHandler<LoginCommandRequest, LoginCommandResponse>
    {
        private readonly IAuthService _authService;
        public LoginCommandHandler(IAuthService authService)
        {
            _authService = authService;
        }

        public async Task<LoginCommandResponse> Handle(LoginCommandRequest request, CancellationToken cancellationToken)
        {       

             var token = await _authService.Login(request.LoginRequestDto);   

            return new LoginCommandResponse { Token = token };
        }
    }
}
