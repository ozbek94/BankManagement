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
    public class TransferRepository : ITransferRepository
    {
        private readonly PostgreSqlContext _context;
        public TransferRepository(PostgreSqlContext context)
        {
            this._context = context;
        }
        public async Task CreateTransfer(Transfer transfer)
        {
            await _context.Transfers.AddAsync(transfer);
            await _context.SaveChangesAsync();
        }

        public async Task<Transfer> GetByTransferId(int id)
        {
            return await _context.Transfers
                .Where(t => t.Id == id)
                .FirstOrDefaultAsync();
        }

        public async Task<List<Transfer>> GetTransfers()
        {
            return await _context.Transfers
                .ToListAsync();
        }

        public async Task Update(Transfer transfer)
        {
            _context.Transfers.Update(transfer);
            await _context.SaveChangesAsync();
        }
    }
}
