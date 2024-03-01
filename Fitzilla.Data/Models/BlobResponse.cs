using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fitzilla.DAL.Models
{
    public class BlobResponse
    {
        public BlobResponse()
        {
            BlobObject = new BlobObject();
        }
        public string? Status { get; set; }
        public bool Error { get; set; }
        public BlobObject BlobObject { get; set; }
    }
}
