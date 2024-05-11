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
        builder.HasKey(expense => expense.Id);
        builder.Property(expense => expense.Id).IsRequired();
        builder.Property(expense => expense.Description).IsRequired();
        builder.Property(expense => expense.Amount).HasColumnType("decimal(18, 6)").HasPrecision(18, 6).IsRequired();
        builder.Property(expense => expense.Date).IsRequired();

        builder.HasOne(x => x.Account)
               .WithMany(x => x.Expenses)
               .HasForeignKey(x => x.AccountId);

        builder.HasOne(expense => expense.Category)
            .WithMany(category => category.Expenses)
            .HasForeignKey(expense => expense.CategoryId)
            .IsRequired();
        builder.HasOne(expense => expense.Budget)
            .WithMany(budget => budget.Expenses)
            .HasForeignKey(expense => expense.BudgetId)
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
