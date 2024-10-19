using Banking_API.Application.Interfaces.Repositories;
using Banking_API.Application.Repositories;
using Banking_API.Domain.Entities;
using Banking_API.Persistence.Contexts;

namespace Banking_API.Persistence.Repositories
{
    public class AccountReadRepository : ReadRepository<Account>,IAccountReadRepository
    {
        public AccountReadRepository(BankingAPIDbContext context):base(context)
        {    
        }
    }
}
