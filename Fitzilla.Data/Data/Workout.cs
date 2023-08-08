using Fitzilla.Data.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fitzilla.Data.Data
{
    public class Workout : IEntity
    {
        public Guid Id { get; set; }

        ///<summary>
        /// Workout's name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Workout's dscription.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Workout's targeted group muscle.
        /// </summary>
        public TargetedMuscle TargetMuscle { get; set; }


        /// <summary>
        /// Workout's creation time.
        /// </summary>
        public DateTimeOffset CreationTime { get; set; }

        /// <summary>
        /// Workout's last modified time.
        /// </summary>
        public DateTimeOffset? LastModifiedTime { get; set; }

        [ForeignKey(nameof(Creator))]
        public string CreatorId { get; set; }
        public User Creator { get; set; }

        public virtual ICollection<Exercise> Exercises { get; set; }
    }
}
