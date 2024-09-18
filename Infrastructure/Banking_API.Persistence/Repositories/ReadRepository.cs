using Banking_API.Application.Repositories;
using Banking_API.Domain.Entities.Common;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Banking_API.Persistence.Repositories
{
    public abstract class ReadRepository<T> : IReadRepository<T> where T : BaseEntity
    {
        private readonly DbContext _context;
        public ReadRepository(DbContext context)
        {
            this._context = context;
        }
        public DbSet<T> Table => _context.Set<T>();

        public async Task<IEnumerable<T>> FindAsync(Expression<Func<T, bool>> predicate)
        {
            return await Table.Where(predicate).ToListAsync();
        }

        public async Task<T> FirstorDefaultAsnc(Expression<Func<T, bool>> predicate)
        {
            return await Table.FirstOrDefaultAsync(predicate);
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await Table.ToListAsync();
        }

        public async Task<T> GetByIdAsync(Guid id)
        {
            return await Table.FirstOrDefaultAsync(data => data.Id == id);
        }
    }
}
