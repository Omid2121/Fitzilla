using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fitzilla.Models.Data;

public abstract class EntityDetail : RecordLog
{
    public string Title { get; set; }
    public string? Description { get; set; }
}
