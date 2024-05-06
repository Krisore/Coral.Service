using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coral.Contract.Tag.Response
{
    public record CreateTagResponse(string name, bool success, string message = "");
}
