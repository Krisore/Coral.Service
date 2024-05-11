using Coral.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Coral.Infrastructure.Persistent.Configuration.BudgetConfiguration;

public class BudgetConfig : IEntityTypeConfiguration<Budget>
{
    public void Configure(EntityTypeBuilder<Budget> builder)
    {
        builder.ToTable("Budgets", "finance");
        builder.HasKey(budget => budget.Id);
        builder.Property(budget => budget.Id).IsRequired();
        builder.Property(budget => budget.Amount)
            .HasColumnType("decimal(18, 6)")
            .HasPrecision(18, 6)
            .IsRequired();
        builder.Property(budget => budget.Name).IsRequired();
        builder.Property(budget => budget.StartDate).IsRequired();
        builder.Property(budget => budget.EndDate).IsRequired();
        builder.HasOne(budget => budget.BudgetTag)
            .WithMany()
            .HasForeignKey(budget => budget.TagId);

    }

   
}

public class TagConfig : IEntityTypeConfiguration<Tag>
{
    public void Configure(EntityTypeBuilder<Tag> builder)
    {
        builder.ToTable("Tags", "utility");
        builder.HasKey(tag => tag.Id);
        builder.Property(tag => tag.Id).IsRequired();
        builder.Property(tag => tag.Name).IsRequired();
        builder.Property(tag => tag.Description).IsRequired(false);
    }
}
