using Bank.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Bank.Domain.Repositories
{
    public interface IWithdrawRepository
    {
        Task CreateWithdraaw(Withdraw withdraw);
        Task<Withdraw> GetByWithdrawId(int id);
        Task<List<Withdraw>> GetWithdraws();
        Task Update(Withdraw withdraw);
    }
}
