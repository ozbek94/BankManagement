using Bank.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Bank.Domain.Repositories
{
    public interface IDepositRepository
    {
        Task CreateDeposit(Deposit deposit);
        Task<Deposit> GetByDepositId(int id);
        Task<List<Deposit>> GetDeposits();
        Task Update(Deposit deposit);
    }
}
