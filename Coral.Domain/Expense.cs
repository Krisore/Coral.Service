using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coral.Domain;

public class Expense
{
    public int Id { get; set; }
    public string Description { get; set; } = default!;
    public decimal Amount { get; set; }
    public DateTime Date { get; set; }
    public int CategoryId { get; set; }
    public Category Category { get; set; } = default!;
    public int BudgetId { get; set; }
    public Budget Budget { get; set; } = default!;
}
