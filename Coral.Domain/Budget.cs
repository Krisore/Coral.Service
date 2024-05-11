using System.ComponentModel.DataAnnotations;

namespace Coral.Domain;

public class Budget
{
    public int Id { get; set; }
    public string Name { get; set; } = default!;

    public  decimal Amount { get; set; }

    public  DateTime StartDate { get; set; }
    public  DateTime EndDate { get; set; }
    public int TagId { get; set; }
    public virtual Tag BudgetTag { get; set; } = new();
    public virtual List<Expense> Expenses { get; set; } = new();
}