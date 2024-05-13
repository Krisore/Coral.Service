using Coral.Application.Common.Repositories;
using Coral.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coral.Application.Commons.Repositories
{
    public interface IAccountTypeRepository : IRepository<AccountType>
    {
        Task<bool> CheckIfAccountTypeExistAsync(string name);
    }
}
