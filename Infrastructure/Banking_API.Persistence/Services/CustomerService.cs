using Banking_API.Application.Interfaces.Repositories;
using Banking_API.Application.Repositories;
using Banking_API.Application.Services;
using Banking_API.Domain.Entities;

namespace Banking_API.Persistence.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly ICustomerWriteRepository _customerRepository;

        public CustomerService(ICustomerWriteRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }
        public async Task<Customer?> AddAsync(Customer customer)
        {
            Customer addedCustomer = await _customerRepository.AddAsync(customer);
            return addedCustomer;
        }

    

     
    }
}
