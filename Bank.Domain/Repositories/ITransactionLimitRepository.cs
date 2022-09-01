using Bank.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Bank.Domain.Repositories
{
    public interface ITransactionLimitRepository
    {
        Task CreateTransactionLimit(TransactionLimit trasactionLimit);
        Task<TransactionLimit> GetByTransactionLimitId(int id);
    }
}
