using System.ComponentModel.DataAnnotations;

namespace Coral.Domain;

public class Budget
{
    public int Id { get; set; }
    [Required]
    public string Name { get; set; } = default!;
    [Required]
    public  decimal Amount { get; set; }
    [Required]
    public  DateTime StartDate { get; set; }
    [Required]
    public  DateTime EndDate { get; set; }
    public int TagId { get; set; }
    public virtual Tag BudgetTag { get; set; } = new();
    public virtual List<Expense> Expenses { get; set; } = new();
}