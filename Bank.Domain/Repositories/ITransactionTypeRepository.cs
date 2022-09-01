using Bank.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Bank.Domain.Repositories
{
    public interface ITransactionTypeRepository
    {
        Task CreateTransationType(TransactionType transactionType);
        Task<TransactionType> GetByTransactionTypeId(int id);
    }
}
