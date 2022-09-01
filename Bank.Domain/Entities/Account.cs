using System;
using System.Collections.Generic;
using System.Text;

namespace Bank.Domain.Entities
{
    public class Account : EntityBase
    {
        public string AccountNumber { get; set; }

        public int Balance { get; set; }
        public int CustomerId { get; set; }
        public void deposit(int amount)
        {
            this.Balance += amount;
        }
        public void withdraw(int amount)
        {
            this.Balance -= amount;
        }
    }
}
