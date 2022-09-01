using Bank.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Bank.Domain.Repositories
{
    public interface ICustomerRepository
    {
        Task CreateCustomer(Customer customer);
        Task<Customer> GetByCustomerId(int id);
        Task<List<Customer>> GetCustomers();
        Task Update(Customer customer);
    }
}
