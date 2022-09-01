using Bank.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bank.Data.Context
{
    public class PostgreSqlContext : DbContext
    {
        public PostgreSqlContext(DbContextOptions<PostgreSqlContext> options)
            : base(options)
        {

        }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<Account> Accounts { get; set; }
        public DbSet<Gsm> Gsms { get; set; }
        public DbSet<Adress> Adresses { get; set; }
        public DbSet<CommissionCase> CommissionCases { get; set; }
        public DbSet<TransactionLimit> TransactionLimits { get; set; }
        public DbSet<AccountTransaction> AccountTransactions { get; set; }
        public DbSet<TransactionType> TransactionTypes { get; set; }
        public DbSet<Deposit> Deposits { get; set; }
        public DbSet<Withdraw> Withdraws { get; set; }
        public DbSet<Transfer> Transfers { get; set; }
    }

}
