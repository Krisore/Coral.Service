using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coral.Contract.Tag.Response
{
    public class DeleteTagResponse
    {
        public bool Success { get; set; }
        public string Message { get; set; } = null!;
    }
}
