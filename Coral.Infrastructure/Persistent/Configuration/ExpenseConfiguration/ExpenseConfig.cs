using Coral.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coral.Infrastructure.Persistent.Configuration.ExpenseConfiguration;

public class ExpenseConfig : IEntityTypeConfiguration<Expense>
{
    public void Configure(EntityTypeBuilder<Expense> builder)
    {
        builder.ToTable("Expenses", "finance");
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id).IsRequired();
        builder.Property(x => x.Description).IsRequired();
        builder.Property(x => x.Amount).HasColumnType("decimal(18, 6)").HasPrecision(18, 6).IsRequired();
        builder.Property(x => x.Date).IsRequired();
        builder.HasOne(x => x.Category)
            .WithMany(c => c.Expenses)
            .HasForeignKey(x => x.CategoryId)
            .IsRequired();
        builder.HasOne(x => x.Budget)
            .WithMany(b => b.Expenses)
            .HasForeignKey(x => x.BudgetId)
            .IsRequired();
    }

}


public class CategoryConfig : IEntityTypeConfiguration<Category>
{
    public void Configure(EntityTypeBuilder<Category> builder)
    {
        builder.ToTable("Categories", "utility");
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id).IsRequired();
        builder.Property(x => x.Name).IsRequired();
    }
}
