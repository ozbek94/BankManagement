using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Bank.Domain.Entities
{
    [Table("Transfer")]
    public class Transfer : EntityBase
    {
        public int SenderId { get; set; }
        public int ReceiverId { get; set; }
        public int SenderAccountId { get; set; }
        public int ReceiverAccountId { get; set; }
        public DateTime? CompletionTime { get; set; }
        public bool IsCompleted { get; set; }
        public int Amount { get; set; }
        public Guid AccountTransactionId { get; set; }
        public string BankName { get; set; }
        public int BankId { get; set; }
        public string IBAN { get; set; }
    }
}
