using Bank.Data.Context;
using Bank.Domain.Entities;
using Bank.Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Serilog;
using Serilog.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank.Data.Repositories
{
    public class AccountTransactionRepository : IAccountTransactionRepository
    {
        private readonly PostgreSqlContext _context;
        private readonly ILogger<AccountTransactionRepository> _logger;

        public AccountTransactionRepository(PostgreSqlContext context, ILogger<AccountTransactionRepository> logger)
        {
            this._context = context;
            this._logger = logger;
        }
        public async Task CreateAccountTransactions(List<AccountTransaction> accountTransactions)
        {
            await _context.AddRangeAsync(accountTransactions);
            await _context.SaveChangesAsync();
        }

        public async Task<List<AccountTransaction>> GetAccountTransactionsById(Guid guid)
        {
            return await _context.AccountTransactions
                .Where(x => x.TransactionId == guid)
                .ToListAsync();
        }

        public async Task<List<AccountTransaction>> GetAccountTransactionsByTransactionType(int transactionTypeId)
        {
            return await _context.AccountTransactions
                .Where(x => x.TransactionTypeId == transactionTypeId)
                .ToListAsync();
        }

        public async Task UpdateAccountTransactions(List<AccountTransaction> accountTransactions)
        {
            _context.UpdateRange(accountTransactions);
            await _context.SaveChangesAsync();

        }
    }
}
