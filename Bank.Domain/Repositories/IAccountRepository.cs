using Bank.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Bank.Domain.Repositories
{
    public interface IAccountRepository
    {
        Task<Account> GetByAccountId(int id);
        Task UpdateAccount(Account account);
        Task CreateAccount(Account account);
    }
}
