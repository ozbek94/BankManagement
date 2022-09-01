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
    public class CommissionCaseRepository : ICommissionCaseRepository
    {
        private readonly PostgreSqlContext _context;

        public CommissionCaseRepository(PostgreSqlContext context)
        {
            this._context = context;
        }

        public async Task CreateCase(CommissionCase commissionCase)
        {
            await _context.CommissionCases.AddAsync(commissionCase);
            await _context.SaveChangesAsync();
        }

        public async Task<CommissionCase> GetByCaseId(int id)
        {
            return await _context.CommissionCases
                .Where(c => c.Id == id)
                .FirstOrDefaultAsync();
        }

        public async Task<CommissionCase> GetByCaseTransactionId(int TransactionTypeId)
        {
            return await _context.CommissionCases
                .Where(c => ((int)c.TransactionTypeId) == TransactionTypeId)
                .FirstOrDefaultAsync();
        }

        public async Task UpdateCommissionCase(CommissionCase commissionCase)
        {
            _context.CommissionCases.Update(commissionCase);
            await _context.SaveChangesAsync();
        }
    }
}
