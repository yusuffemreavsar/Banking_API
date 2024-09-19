using Banking_API.Application.Dtos;
using Banking_API.Application.Features.Auth.Dtos;

namespace Banking_API.Application.Services
{
    public interface IAuthService
    {
        public Task<RegisterResponseDto> Register(RegisterRequestDto registerDto);
        public Task<string> Login(LoginDto loginDto);
        

    }
}
