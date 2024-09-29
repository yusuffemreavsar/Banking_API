using Banking_API.Domain.Entities.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Banking_API.Application.Services
{
    public interface ITokenService
    {
        Task<string> GenerateToken(AppUser user);
        bool ValidateToken(string token);
        ClaimsPrincipal GetPrincipalFromExpiredToken(string token);
    }
}
