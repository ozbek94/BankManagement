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
    public class WithdrawRepository : IWithdrawRepository
    {
        private readonly PostgreSqlContext _context;
        public WithdrawRepository(PostgreSqlContext context)
        {
            this._context = context;
        }
        public async Task CreateWithdraaw(Withdraw withdraw)
        {
           await _context.Withdraws.AddAsync(withdraw);
           await _context.SaveChangesAsync();
        }

        public async Task<Withdraw> GetByWithdrawId(int id)
        {
           return await _context.Withdraws
                .Where(w => w.Id == id)
                .FirstOrDefaultAsync();
        }

        public async Task<List<Withdraw>> GetWithdraws()
        {
            return await _context.Withdraws
                .ToListAsync();
        }

        public async Task Update(Withdraw withdraw)
        {
            _context.Withdraws.Update(withdraw);
            await _context.SaveChangesAsync();
        }
    }
}
