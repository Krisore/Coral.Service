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
    public class AccountTypeRepository : Repository<AccountType>, IAccountTypeRepository
    {
        private readonly DbSet<AccountType> _accountType;

        public AccountTypeRepository(ApplicationDbContext applicationDbContext) : base(applicationDbContext)
        {
            _accountType = applicationDbContext.Set<AccountType>();
        }

        public async Task<bool> CheckIfAccountTypeExistAsync(string name) => await _accountType.AnyAsync(x => x.Name.Equals(name));
        
    }
}
