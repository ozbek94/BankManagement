using Bank.Data.Context;
using Bank.Domain.Entities;
using Bank.Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bank.Data.Repositories
{
    public class CustomerReporsitory : ICustomerRepository
    {
        private readonly PostgreSqlContext _context;

        public CustomerReporsitory(PostgreSqlContext context)
        {
            this._context = context;
        }

        public async Task CreateCustomer(Customer customer)
        {
            await _context.Customers.AddAsync(customer);
            await _context.SaveChangesAsync();
        }

        public async Task<Customer> GetByCustomerId(int id)
        {
            return await _context.Customers
                .Include(c => c.Accounts)
                .Include(g => g.Gsms)
                .Include(g => g.Adresses)
                .Where(x => x.Id == id)
                .FirstOrDefaultAsync();
        }

        public async Task<List<Customer>> GetCustomers()
        {
            return await _context.Customers
                .Include(c => c.Accounts)
                .Include(g => g.Gsms)
                .Include(g => g.Adresses)
                .ToListAsync();
        }

        public async Task Update(Customer customer)
        {
            _context.Customers.Update(customer);
            await _context.SaveChangesAsync();
        }

        
    }
}
