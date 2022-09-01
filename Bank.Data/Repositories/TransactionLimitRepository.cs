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
    public class TransactionLimitRepository : ITransactionLimitRepository
    {
        private readonly PostgreSqlContext _context;

        public TransactionLimitRepository(PostgreSqlContext context)
        {
            this._context = context;
        }
        public async Task CreateTransactionLimit(TransactionLimit trasactionLimit)
        {
            await _context.TransactionLimits.AddAsync(trasactionLimit);
            await _context.SaveChangesAsync();
        }

        public async Task<TransactionLimit> GetByTransactionLimitId(int id)
        {
            return await _context.TransactionLimits
                .Where(t => t.Id == id)
                .FirstOrDefaultAsync();
        }
    }
}
