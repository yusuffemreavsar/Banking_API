using Banking_API.Application.Features.Auth.Login.Dtos;
using Banking_API.Application.Features.Auth.Register.Dtos;
using Banking_API.Domain.Entities.Identity;

namespace Banking_API.Application.Services
{
    public interface IAuthService
    {
        public Task<RegisterResponseDto> Register(RegisterRequestDto registerDto);
        public Task<string> Login(AppUser user);
        

    }
}
