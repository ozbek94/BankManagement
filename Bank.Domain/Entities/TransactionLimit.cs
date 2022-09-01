using System;
using System.Collections.Generic;
using System.Text;

namespace Bank.Domain.Entities
{
    public class TransactionLimit : EntityBase
    {
        public string TransferTypeName { get; set; }
        public int TransferTypeLimit { get; set; } 
    }
}
