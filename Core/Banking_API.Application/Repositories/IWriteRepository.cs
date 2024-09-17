using Banking_API.Domain.Entities.Common;

namespace Banking_API.Application.Repositories
{
    public interface IWriteRepository<T>:IBaseRepository<T> where T : BaseEntity
    {
        public Task<bool> AddAsync(T entity);
        public Task<bool> UpdateAsync(T entity);
        public Task<bool> DeleteAsync(T entity);
        public Task<bool> DeleteByIdAsync(Guid id);
    }
}
