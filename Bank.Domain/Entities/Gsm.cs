using System;
using System.Collections.Generic;
using System.Text;

namespace Bank.Domain.Entities
{
    public class Gsm : EntityBase
    {
        public string GsmNumber { get; set; }
        public int CustomerId { get; set; }
    }
}
