using Banking_API.Application.Repositories;
using Banking_API.Domain.Entities.Common;
using Microsoft.EntityFrameworkCore;


namespace Banking_API.Persistence.Repositories
{
    public abstract class WriteRepository<T> : IWriteRepository<T> where T : BaseEntity
    {
        private readonly DbContext _context;
        public WriteRepository(DbContext context)
        {
            this._context = context;
        }
        public DbSet<T> Table => _context.Set<T>();

        public async Task<T> AddAsync(T entity)
        {
            Table.Entry(entity).State = EntityState.Added;
            await _context.SaveChangesAsync();
            
            return entity;
        }

        public async Task<T> DeleteAsync(T entity)
        {
            Table.Entry(entity).State = EntityState.Deleted;
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task<T> DeleteByIdAsync(Guid id)
        {
            var model = await Table.FirstOrDefaultAsync(t=>t.Id==id);
            Table.Entry(model).State = EntityState.Deleted;
            await _context.SaveChangesAsync();
            return model;
        }

        public async Task<T> UpdateAsync(T entity)
        {
            Table.Entry(entity).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return entity;
        }
    }
}
