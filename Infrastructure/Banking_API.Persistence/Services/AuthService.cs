using AutoMapper;
using Banking_API.Application.Dtos;
using Banking_API.Application.Features.Auth.Dtos;
using Banking_API.Application.Services;
using Banking_API.Domain.Entities.Identity;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Identity;

namespace Banking_API.Persistence.Services
{
    public class AuthService : IAuthService
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly IMapper _mapper;
        public AuthService(UserManager<AppUser> userManager, IMapper mapper)
        {
            _userManager = userManager;
            _mapper = mapper;
        }
        public Task<string> Login(LoginDto loginDto)
        {
            throw new NotImplementedException();
        }

        public async Task<RegisterResponseDto> Register(RegisterRequestDto registerDto)
        {
            AppUser appUser= _mapper.Map<AppUser>(registerDto);
            appUser.Id = Guid.NewGuid().ToString();
            var result=await _userManager.CreateAsync(appUser,registerDto.Password);
            RegisterResponseDto response = new() {Succeeded=result.Succeeded};
            if (result.Succeeded)
            {
                response.Message = "Register success.";
            }
            else
                foreach (var error in result.Errors)
                    response.Message += $"{error.Code} - {error.Description}\n";


            return response;
        }
    }
}
