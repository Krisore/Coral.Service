using Coral.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coral.Infrastructure.Persistent.Configuration.AccountConfiguration;

public class AccountConfig : IEntityTypeConfiguration<Account>
{
    public void Configure(EntityTypeBuilder<Account> builder)
    {
        builder.ToTable("Accounts", "finance");

        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id).IsRequired();
        builder.Property(x => x.Name).HasMaxLength(50).IsRequired();
        builder.Property(x => x.Description).HasMaxLength(250).IsRequired();

        builder.HasOne(x => x.Balance)
            .WithOne()
            .HasForeignKey<Account>("BalanceId");
        builder.HasOne(x => x.Type)
            .WithMany()
            .HasForeignKey(x => x.TypeId)
            .IsRequired();


    }
}


public class BalanceConfig : IEntityTypeConfiguration<Balance>
{
    public void Configure(EntityTypeBuilder<Balance> builder)
    {
        builder.ToTable("Balances", "finance");
        builder.HasKey(x => x.Id); 
        builder.Property(x => x.Id).IsRequired();
        builder.Property(x => x.AccountId).IsRequired();
        builder.Property(x => x.Amount).HasColumnType("decimal(18, 6)").IsRequired();
    }
}

public class AccountTypeConfig : IEntityTypeConfiguration<AccountType>
{
    public void Configure(EntityTypeBuilder<AccountType> builder)
    {
        builder.ToTable("AccountTypes", "utility");
        builder.HasKey(x => x.Id); 
        builder.Property(x => x.Id).IsRequired(); 
        builder.Property(x => x.Name).IsRequired();
        builder.Property(x => x.Description).IsRequired(false); 

        builder.HasMany(x => x.Accounts)
            .WithOne(a => a.Type)
            .HasForeignKey(a => a.TypeId)
            .IsRequired();
    }
}
