using AutoMapper;
using Banking_API.Application.Features.Auth.Dtos;
using Banking_API.Application.Services;
using MediatR;

namespace Banking_API.Application.Features.Auth.Commands
{
    public class RegisterCommandHandler : IRequestHandler<RegisterCommandRequest, RegisterCommandResponse>
    {
        private readonly IAuthService _authService;

        public RegisterCommandHandler(IAuthService authService)
        {
            _authService = authService;
        }

        public async Task<RegisterCommandResponse> Handle(RegisterCommandRequest request, CancellationToken cancellationToken)
        {
            var item = await _authService.Register(request._RegisterRequestDto);
            var registerResponseDto = new RegisterResponseDto
            {
                Message = item.Message,
                Succeeded = item.Succeeded
            };

            return new RegisterCommandResponse
            {
                RegisterDto = registerResponseDto
            };
        }
    }

}
