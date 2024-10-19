using Banking_API.Application.Interfaces.Repositories;
using Banking_API.Application.Interfaces.UnitOfWork;
using Banking_API.Application.Repositories;
using Banking_API.Domain.Entities;
using Banking_API.Domain.Entities.Common;
using Banking_API.Persistence.Contexts;
using Banking_API.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Banking_API.Persistence.UnitofWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly BankingAPIDbContext _context;

        public UnitOfWork(BankingAPIDbContext context)
        {
            this._context = context;
        }

        public async ValueTask DisposeAsync() => await _context.DisposeAsync();

        IReadRepository<T> IUnitOfWork.GetReadRepository<T>()
        {
            return new ReadRepository<T>(_context);
        }

        IWriteRepository<T> IUnitOfWork.GetWriteRepository<T>()
        {
            return new WriteRepository<T>(_context);
        }

        int IUnitOfWork.Save()
        {
            return _context.SaveChanges();
        }

        Task<int> IUnitOfWork.SaveChanges()
        {
            return _context.SaveChangesAsync();
        }
    }
}
