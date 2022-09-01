using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Bank.Domain.Entities
{
    [Table("AccountTransaction")]
    public class AccountTransaction : EntityBase
    {
        public Guid TransactionId { get; set; } 
        public int TransactionTypeId { get; set; }
        public string TransactionTypeName { get; set; }
        public int PartyId { get; set; }
        public double Debit { get; set; }
        public double Credit { get; set; }
    }
}
