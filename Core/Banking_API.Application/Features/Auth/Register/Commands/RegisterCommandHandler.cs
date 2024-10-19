using AutoMapper;
using Banking_API.Application.Features.Auth.Register.Dtos;
using Banking_API.Application.Services;
using Banking_API.Domain.Entities.Identity;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace Banking_API.Application.Features.Auth.Register.Commands
{
    public class RegisterCommandHandler : IRequestHandler<RegisterCommandRequest, RegisterCommandResponse>
    {
        private readonly IAuthService _authService;
        private readonly UserManager<AppUser> _userManager;
        private readonly ICustomerService _customerService;


        public RegisterCommandHandler(IAuthService authService, UserManager<AppUser> userManager, ICustomerService customerService)
        {
            _authService = authService;
            _userManager = userManager;
            _customerService = customerService;
        }

        public async Task<RegisterCommandResponse> Handle(RegisterCommandRequest request, CancellationToken cancellationToken)
        {
            var item = await _authService.Register(request._RegisterRequestDto); 
            var registerResponseDto = new RegisterResponseDto
            {
                Message = item.Message,
                Succeeded = item.Succeeded
            };
            var appUser = await _userManager.FindByEmailAsync(request._RegisterRequestDto.Email);
            var appUserId = appUser.Id;
            if (item.Succeeded)
            {
                await _customerService.AddAsync(new()
                {
                    Id = Guid.NewGuid(),
                    AppUserId = appUserId,
                    FirstName = appUser.FirstName,
                    LastName = appUser.LastName,
                    PhoneNumber = appUser.PhoneNumber,
                    Email = appUser.Email,
                    CreatedDate = DateTime.Now,
                    UpdatedDate = DateTime.Now,
                });
            }

            return new RegisterCommandResponse
            {
                RegisterDto = registerResponseDto
            };
        }
    }

}
