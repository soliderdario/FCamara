﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Super.Digital.Domain.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Super.Digital.Data.Mappings
{
    public class AccountMapping : IEntityTypeConfiguration<AccountModel>
    {
        public void Configure(EntityTypeBuilder<AccountModel> builder)
        {
            builder.ToTable("Account");
            builder.Property(f => f.AccountId).IsRequired().HasMaxLength(40);
            builder.HasKey(f => f.AccountId);
            builder.Property(f => f.Value).IsRequired().HasColumnType("decimal(18,2)");
            builder.Property(f => f.Transaction).IsRequired();
            builder.Property(f => f.Number).IsRequired().HasMaxLength(7);
            builder.Property(f => f.DateCreate).IsRequired();
            builder.Property(f => f.DateUpdate).IsRequired(false);
        }
    }
}
