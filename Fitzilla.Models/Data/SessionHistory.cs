using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fitzilla.Models.Data;

public class SessionHistory : IEntity
{
    public Guid Id { get; set; }
    public DateTimeOffset FinishedAt { get; set; }

    public Guid SessionId { get; set; }
    public virtual Session Session { get; set; }
}
