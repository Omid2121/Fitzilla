using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fitzilla.DAL.Models
{
    public class BlobObject
    {
        public Stream? Content { get; set; }
        public string? ContentType { get; set; }
    }
}
