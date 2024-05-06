using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coral.Contract.Category.Request
{
    public record UpdateCategoryRequest(int Id, string Name);
}
