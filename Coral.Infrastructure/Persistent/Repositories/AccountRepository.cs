using Coral.Application.Commons.Repositories;
using Coral.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coral.Infrastructure.Persistent.Repositories
{
    public class AccountRepository : Repository<Account>, IAccountRepository
    {
        private readonly DbSet<Account> _accounts;
        public AccountRepository(ApplicationDbContext applicationDbContext) : base(applicationDbContext)
        {
            _accounts = applicationDbContext.Set<Account>();
        }
    }
}
