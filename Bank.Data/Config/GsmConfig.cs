using Bank.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bank.Data.Config
{
    public class GsmConfig : IEntityTypeConfiguration<Gsm>
    {
        public void Configure(EntityTypeBuilder<Gsm> builder)
        {
            builder.HasQueryFilter(x => x.DeleteTime == null);
        }
    }
}
