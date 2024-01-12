using System.ComponentModel.DataAnnotations.Schema;

namespace Fitzilla.Models.Data
{
    public class Exercise : EntityDetail
    {        
        public int Set { get; set; }
        
        public int Rep { get; set; }
        
        public double Weight { get; set; }

        public Guid MediaId { get; set; }
        public Media Media { get; set; }

        public Guid? SessionId { get; set; }
        public Session? Session { get; set; }
       
        public string CreatorId { get; set; }
        public User Creator { get; set; }
    }
}
