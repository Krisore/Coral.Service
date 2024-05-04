namespace Coral.Domain;

public class Category
{
    public int Id { get; set; }
    public string Name { get; set; } = default!;
    public List<Expense> Expenses { get; set; } = new();
}