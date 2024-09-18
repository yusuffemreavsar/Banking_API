using Banking_API.Application.Repositories;
using Banking_API.Domain.Entities;
using Banking_API.Persistence.Contexts;

namespace Banking_API.Persistence.Repositories
{
    public class CustomerReadRepository:ReadRepository<Customer>,ICustomerReadRepository
    {
        public CustomerReadRepository(BankingAPIDbContext context) : base(context)
        {
        }
    }
}
