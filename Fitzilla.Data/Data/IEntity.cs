using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fitzilla.Data.Data
{
    public interface IEntity
    {
        Guid Id { get; set; }
        DateTimeOffset CreationTime { get; set; }
        DateTimeOffset? LastModifiedTime { get; set; }
    }
}
