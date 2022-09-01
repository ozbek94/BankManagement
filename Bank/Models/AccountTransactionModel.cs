using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BankUI.Models
{
    public class AccountTransactionModel
    {
        public Guid TransactionId { get; set; }
        public int PartyId { get; set; }
        public double Debit { get; set; }
        public double Credit { get; set; }
        public string TransactionTypeName { get; set; }
    }
}
