using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Bank.Domain.Entities
{
    public class Customer : EntityBase
    {

        [Required]
        [Column(TypeName = "VARCHAR")]
        [MaxLength(30)]
        public string Name { get; set; }

        [Required]
        [Column(TypeName = "VARCHAR")]
        [MaxLength(30)]
        public string Surname { get; set; }
        public string DateOfBirth { get; set; }

        [Column(TypeName = "CHAR")]
        [MaxLength(11)]
        public string NationalId { get; set; }
        public ICollection<Account> Accounts { get; set; }
        public ICollection<Gsm> Gsms { get; set; }
        public ICollection<Adress> Adresses { get; set; }
    }
}
