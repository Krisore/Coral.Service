namespace Coral.Domain;

public class Category
{
    public int Id { get; set; }
    public string Name { get; set; } = default!;
    public virtual List<Expense> Expenses { get; set; } = new();
}