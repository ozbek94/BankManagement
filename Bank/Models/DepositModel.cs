using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BankUI.Models
{
    public class DepositModel
    {
        public int PartyId { get; set; }
        public int AccountId { get; set; }
        public DateTime? CompletionTime { get; set; }
        public bool IsCompleted { get; set; }
        public int Amount { get; set; }
        public Guid AccountTransactionId { get; set; }
    }
}
