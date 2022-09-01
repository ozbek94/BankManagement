using System;
using System.Collections.Generic;
using System.Text;

namespace Bank.Domain.Entities
{
    public abstract class EntityBase
    {
        public int Id { get; set; }
        public DateTime InsertTime { get; set; }
        public DateTime? DeleteTime { get; set; }
    }
}
