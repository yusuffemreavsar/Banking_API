using Banking_API.Application.Interfaces.Repositories;
using Banking_API.Domain.Entities.Common;
using System.Linq.Expressions;

namespace Banking_API.Application.Repositories
{
    public interface IReadRepository<T>:IBaseRepository<T> where T : BaseEntity
    {
       public Task<T> GetByIdAsync(Guid id); 
       public Task<IEnumerable<T>> GetAllAsync();
       public Task<IEnumerable<T>> FindAsync(Expression<Func<T, bool>> predicate);
       public Task<T> FirstorDefaultAsnc(Expression<Func<T, bool>> predicate);

    }
}
