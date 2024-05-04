using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coral.Contract.Category.Request
{
    public class AddCategoryRequest
    {
        public required string Name { get; set; }
    }
}
