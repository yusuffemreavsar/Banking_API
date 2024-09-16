using Banking_API.Domain.Entities;
using Banking_API.Domain.Entities.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Banking_API.Persistence.Contexts
{
    public class BankingAPIDbContext : IdentityDbContext<AppUser,AppRole,Guid>
    {
        public BankingAPIDbContext(DbContextOptions options):base(options){ }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<Account> Accounts { get; set; }
        public DbSet<Transaction> Transactions { get; set; }

    }
}
