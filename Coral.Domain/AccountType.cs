using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coral.Domain;

public class AccountType
{
    public int Id { get; set; }
    public string Name { get; set; } = default!;
    public string Description { get; set; } = string.Empty;

    public virtual List<Account> Accounts { get; set; } = new();
}
