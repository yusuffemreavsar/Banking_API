﻿using Banking_API.Application.Repositories;
using Banking_API.Domain.Entities;
using Banking_API.Persistence.Contexts;


namespace Banking_API.Persistence.Repositories
{
    public class TransactionReadRepository : ReadRepository<Transaction>,ITransactionReadRepository
    {
        public TransactionReadRepository(BankingAPIDbContext context): base(context)
        {
            
        }
    }
}
