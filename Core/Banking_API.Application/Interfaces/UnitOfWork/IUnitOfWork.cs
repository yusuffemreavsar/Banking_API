
using Banking_API.Application.Repositories;
using Banking_API.Domain.Entities.Common;

namespace Banking_API.Application.Interfaces.UnitOfWork
{
    public interface IUnitOfWork : IAsyncDisposable
    {
        public IWriteRepository<T> GetWriteRepository<T>() where T : BaseEntity;

        public IReadRepository<T> GetReadRepository<T>() where T : BaseEntity;

        public Task<int> SaveChanges();

        public int Save();

       
    }
}
