using Banking_API.Domain.Entities.Common;
using Microsoft.EntityFrameworkCore;

namespace Banking_API.Application.Repositories
{
    public interface IBaseRepository<T> where T : BaseEntity
    {
        public DbSet<T> Table {  get; }
    }
}
