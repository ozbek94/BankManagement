using System;
using System.Collections.Generic;
using System.Text;

namespace Bank.Domain.Entities
{
    public class Adress : EntityBase
    {
        public string CityName { get; set; }
        public int CityNumber { get; set; }
    }
}
