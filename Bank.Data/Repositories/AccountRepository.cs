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
    public class AccountReporsitory : IAccountRepository
    {
        private readonly PostgreSqlContext _context;

        public AccountReporsitory(PostgreSqlContext context)
        {
            this._context = context;
        }

        public async Task CreateAccount(Account account)
        {
            await _context.Accounts.AddAsync(account);
            await _context.SaveChangesAsync();
        }

        public async Task<Account> GetByAccountId(int id)
        {
            return await _context.Accounts
                .Where(a => a.Id == id)
                .FirstOrDefaultAsync();
        }


        public async Task UpdateAccount(Account account)
        {
            _context.Accounts.Update(account);
            await _context.SaveChangesAsync();
        }
    }
}
