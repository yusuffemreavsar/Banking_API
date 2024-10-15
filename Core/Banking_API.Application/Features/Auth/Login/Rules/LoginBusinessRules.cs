using AutoMapper;
using Banking_API.Application.Exceptions;
using Banking_API.Application.Features.Auth.Login.Dtos;
using Banking_API.Domain.Entities.Identity;
using Microsoft.AspNetCore.Identity;

namespace Banking_API.Application.Features.Auth.Login.Rules
{
    public class LoginBusinessRules
    {
       
       private readonly UserManager<AppUser> _userManager;

        public LoginBusinessRules(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
 
        }
        public Task UserShouldBeExists(AppUser? user)
        {
            if (user == null) throw new NotFoundException("User don't exists.");
            return Task.CompletedTask;
        }

        public async Task CheckPasswordAsync(AppUser user,string password)
        {
           var chechPassword = await _userManager.CheckPasswordAsync(user, password);
            if (!chechPassword)
            {
                throw new BusinessException("Password not matched!");
            }
        }



    }
}
