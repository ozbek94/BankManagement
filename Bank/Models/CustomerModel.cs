using Bank.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BankUI.Models
{
    public class CustomerModel
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string NationalId { get; set; }
        public string DateOfBirth { get; set; }
        public ICollection<Gsm> Gsms { get; set; }
        public ICollection<Account> Accounts { get; set; }
        public ICollection<Adress> Adresses { get; set; }
    }
}
