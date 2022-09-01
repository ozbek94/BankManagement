using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BankUI.Models
{
    public class TransferModel
    {
        public int SenderId { get; set; }
        public int ReceiverId { get; set; }
        public int SenderAccountId { get; set; }
        public int ReceiverAccountId { get; set; }
        public DateTime? CompletionTime { get; set; }
        public bool IsCompleted { get; set; }
        public Guid AccountTransactionId { get; set; }
    }
}
