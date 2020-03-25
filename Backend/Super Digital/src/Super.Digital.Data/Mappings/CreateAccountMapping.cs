using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Super.Digital.Domain.Model;

namespace Super.Digital.Data.Mappings
{
    public class CreateAccountMapping : IEntityTypeConfiguration<AccountModel>
    {
        public void Configure(EntityTypeBuilder<AccountModel> builder)
        {
            builder.ToTable("Account");
            builder.Property(f => f.AccountId).IsRequired().HasMaxLength(40);
            builder.HasKey(f => f.AccountId);           
            builder.Property(f => f.Number).IsRequired().HasMaxLength(7);
            builder.Property(f => f.DateCreate).IsRequired();
            builder.Property(f => f.DateUpdate).IsRequired(false);
            builder.HasMany(owner => owner.Entries).WithOne(child => child.Account).HasForeignKey(fk => fk.AccountId).OnDelete(DeleteBehavior.Cascade);
        }
    }


    public class AccountEntryMapping : IEntityTypeConfiguration<AccountEntryModel>
    {
        public void Configure(EntityTypeBuilder<AccountEntryModel> builder)
        {
            builder.ToTable("AccountEntry");
            builder.Property(f => f.AccountEntryId).IsRequired().HasMaxLength(40);
            builder.HasKey(f => f.AccountEntryId);
            builder.Property(f => f.AccountId).IsRequired().HasMaxLength(40);
            builder.Property(f => f.Value).IsRequired().HasColumnType("decimal(18,2)");                
            builder.Property(f => f.DateCreate).IsRequired();
            builder.Property(f => f.DateUpdate).IsRequired(false);
        }
    }
}
