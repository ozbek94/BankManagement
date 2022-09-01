using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Bank.Domain.Entities
{
    [Table("Deposit")]
    public class Deposit : EntityBase
    {
        public int PartyId { get; set; }
        public int AccountId { get; set; }
        public DateTime? CompletionTime { get; set; }
        public bool IsCompleted { get; set; }
        public int Amount { get; set; }
        public Guid AccountTransactionId { get; set; }
        public string BankName { get; set; }
        public int BankId { get; set; }
        public string IBAN { get; set; }
    }
}
