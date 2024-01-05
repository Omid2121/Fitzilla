using Fitzilla.Models.Enums;
using System.ComponentModel.DataAnnotations.Schema;

namespace Fitzilla.Models.Data
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
