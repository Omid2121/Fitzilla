using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fitzilla.Models.Data
{
    public class Media : EntityDetail
    {
        public string ImageUrl { get; set; }

        public string? VideoUrl { get; set; }

        public string CreatorId { get; set; }
        public User Creator { get; set; }

        public virtual ICollection<ExerciseTemplate> ExerciseTemplates { get; set; }

        public virtual ICollection<Exercise> Exercises { get; set; }
    }
}
