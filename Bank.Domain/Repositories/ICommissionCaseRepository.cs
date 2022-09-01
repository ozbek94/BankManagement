using Bank.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Bank.Domain.Repositories
{
    public interface ICommissionCaseRepository
    {
        Task UpdateCommissionCase(CommissionCase commissionCase);
        Task<CommissionCase> GetByCaseId(int id);
        Task<CommissionCase> GetByCaseTransactionId(int TransactionId);
        Task CreateCase(CommissionCase commissionCase);
    }
}
