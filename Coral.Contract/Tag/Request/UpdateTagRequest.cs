using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coral.Contract.Tag.Request;

public record UpdateTagRequest(int Id , string Name, string Description = "");
