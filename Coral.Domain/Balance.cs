using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coral.Domain
{
    public class Balance
    {
        public int Id { get; set; }
        public decimal Amount { get; set; }
        public int AccountId { get; set; }
        public virtual Account Account { get; set; } = null!;
        public DateTime BalanceAsOf { get; set; } = DateTime.Now;
    }
}
