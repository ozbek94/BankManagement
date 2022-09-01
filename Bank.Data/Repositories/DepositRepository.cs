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
    public class DepositRepository : IDepositRepository
    {
        private readonly PostgreSqlContext _context;
        public DepositRepository(PostgreSqlContext context)
        {
            this._context = context;
        }
        public async Task CreateDeposit(Deposit deposit)
        {
            await _context.Deposits.AddAsync(deposit);
            await _context.SaveChangesAsync();
        }

        public async Task<Deposit> GetByDepositId(int id)
        {
            return await _context.Deposits
                .Where(d => d.Id == id)
                .FirstOrDefaultAsync();  
        }

        public async Task<List<Deposit>> GetDeposits()
        {
            return await _context.Deposits
                .ToListAsync();
        }

        public async Task Update(Deposit deposit)
        {
            _context.Deposits.Update(deposit);
            await _context.SaveChangesAsync();
        }
    }
}
