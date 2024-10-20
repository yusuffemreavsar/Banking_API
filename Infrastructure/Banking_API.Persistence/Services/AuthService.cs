﻿using AutoMapper;
using Banking_API.Application.Exceptions;
using Banking_API.Application.Features.Auth.Login.Dtos;
using Banking_API.Application.Features.Auth.Register.Dtos;
using Banking_API.Application.Repositories;
using Banking_API.Application.Services;
using Banking_API.Domain.Entities;
using Banking_API.Domain.Entities.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;

namespace Banking_API.Persistence.Services
{
    public class AuthService : IAuthService
    {
        private readonly UserManager<AppUser> _userManager;

        private readonly IMapper _mapper;
        private readonly ITokenService _tokenService;
        public AuthService(UserManager<AppUser> userManager, IMapper mapper, IConfiguration configuration, ITokenService tokenService)
        {
            _userManager = userManager;
            _mapper = mapper;
            _tokenService = tokenService;
        }


        public async Task<string> Login(AppUser user)
        {
            if (user != null)
            {
                var token = await _tokenService.GenerateToken(user);
                return token;
            }
            throw  new BusinessException("Token not created.Invalid Opreation");
        }

        public async Task<RegisterResponseDto> Register(RegisterRequestDto registerDto)
        {
            AppUser appUser= _mapper.Map<AppUser>(registerDto);
            appUser.Id = Guid.NewGuid();
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
