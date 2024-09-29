using Banking_API.Application.Features.Auth.Login.Dtos;
using Banking_API.Application.Features.Auth.Register.Dtos;

namespace Banking_API.Application.Services
{
    public interface IAuthService
    {
        public Task<RegisterResponseDto> Register(RegisterRequestDto registerDto);
        public Task<string> Login(LoginRequestDto loginDto);
        

    }
}
