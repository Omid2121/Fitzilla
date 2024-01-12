using Fitzilla.Models.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fitzilla.Models.Data
{
    public class Session : EntityDetail
    {
        public TargetedMuscle TargetMuscle { get; set; }

        public bool IsActive { get; set; }
        
        public DateTimeOffset? ActivatedAt { get; set; }
        
        public DateTimeOffset? DeactivatedAt { get; set; }

        public Guid PlanId { get; set; }
        public Plan Plan { get; set; }
        
        public string CreatorId { get; set; }
        public User Creator { get; set; }
        
        public virtual ICollection<Exercise> Exercises { get; set; }
    }
}
