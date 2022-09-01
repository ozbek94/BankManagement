using Bank.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Bank.Domain.Repositories
{
    public interface ITransferRepository
    {
        Task CreateTransfer(Transfer transfer);
        Task<Transfer> GetByTransferId(int id);
        Task<List<Transfer>> GetTransfers();
        Task Update(Transfer transfer);
    }
}
