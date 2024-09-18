using Banking_API.Domain.Entities.Common;

namespace Banking_API.Application.Repositories
{
    public interface IWriteRepository<T>:IBaseRepository<T> where T : BaseEntity
    {
        public Task<T> AddAsync(T entity);
        public Task<T> UpdateAsync(T entity);
        public Task<T> DeleteAsync(T entity);
        public Task<T> DeleteByIdAsync(Guid id);
    }
}
