using Bank.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bank.Domain.Entities
{
    public class CommissionCase : EntityBase
    {        
        //public string ComissionTypeName { get; set; }
        public TransactionTypeEnum TransactionTypeId { get; set; }
        public int ComissionAmount { get; set; }

        public double Bsmv()
        {
            return BsmvFormule(ComissionAmount);
        }

        public double BsmvFormule(int ComissionAmount)
        {
            double amount = (((double)(ComissionAmount) * 100) / 105);
            amount = Math.Round(((double)ComissionAmount - (amount)),2);
            return amount;
        }

    }
}
