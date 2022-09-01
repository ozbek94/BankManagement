using Bank.Data.Context;
using Bank.Domain.Entities;
using Bank.Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank.Data.Repositories
{
    public class TransactionTypeRepository : ITransactionTypeRepository
    {
        private readonly PostgreSqlContext _context;

        public TransactionTypeRepository(PostgreSqlContext context)
        {
            this._context = context;
        }
        public async Task CreateTransationType(TransactionType transactionType)
        {
            await _context.AddAsync(transactionType);
            await _context.SaveChangesAsync();

        }

        public async Task<TransactionType> GetByTransactionTypeId(int id)
        {
            return await _context.TransactionTypes
                .Where(tt => tt.Id == id)
                .FirstOrDefaultAsync();
        }
    }
}
