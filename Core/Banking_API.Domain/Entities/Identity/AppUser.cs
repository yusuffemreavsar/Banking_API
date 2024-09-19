using Microsoft.AspNetCore.Identity;

namespace Banking_API.Domain.Entities.Identity
{
    public class AppUser : IdentityUser<string>
    {
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
    }
}
