using Banking_API.Domain.Entities;

namespace Banking_API.Application.Services
{
    public interface ICustomerService
    {
        public  Task<Customer?> AddAsync(Customer customer);

    }
}
