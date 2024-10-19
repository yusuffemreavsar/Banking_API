using Banking_API.Application.Interfaces.Repositories;
using Banking_API.Application.Repositories;
using Banking_API.Domain.Entities;


namespace Banking_API.Application.Interfaces.Repositories
{
    public interface ITransactionWriteRepository : IWriteRepository<Transaction>
    {

    }
}
