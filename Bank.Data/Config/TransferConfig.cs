using Bank.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bank.Data.Config
{
    public class TransferConfig : IEntityTypeConfiguration<Transfer>
    {
        public void Configure(EntityTypeBuilder<Transfer> builder)
        {
            builder.HasQueryFilter(d => d.DeleteTime == null);
            builder.HasQueryFilter(d => d.CompletionTime == null);
            builder.HasQueryFilter(d => d.IsCompleted == false);
        }
    }
}
