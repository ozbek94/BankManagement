using Bank.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Bank.Domain.Repositories
{
    public interface IAccountTransactionRepository
    {
        Task CreateAccountTransactions(List<AccountTransaction> accountTransactions);
        Task<List<AccountTransaction>> GetAccountTransactionsById(Guid guid);
        Task<List<AccountTransaction>> GetAccountTransactionsByTransactionType(int transactionTypeId);
        Task UpdateAccountTransactions(List<AccountTransaction> accountTransactions);
    }
}
