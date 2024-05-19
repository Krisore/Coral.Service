using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coral.Domain;

public class Account
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;


    public int AccountTypeId { get; set; }
    public virtual AccountType AccountType { get; set; } = null!;
    public virtual Balance Balance { get; set; } = new();
    public List<Expense> Expenses { get; set; } = new();
}
