using System.ComponentModel.DataAnnotations.Schema;

namespace Fitzilla.Models.Data
{
    public class Exercise : IEntity
    {
        public Guid Id { get; set; }

        ///<summary>
        /// Exercise's name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Exercise's description
        /// </summary>
        public string Description { get; set; }

        ///<summary>
        /// Exercise's image
        /// </summary>
        public string Image { get; set; }


        ///<summary>
        /// Exercise's set
        /// </summary>
        public int Set { get; set; }

        ///<summary>
        /// Exercise's repetition
        /// </summary>
        public int Rep { get; set; }

        /// <summary>
        /// Weight amount for exercise.
        /// </summary>
        public double Weight { get; set; }
        
        /// <summary>
        /// Exercise's creation time.
        /// </summary>
        public DateTimeOffset CreationTime { get; set; }

        /// <summary>
        /// Exercise's last modified time.
        /// </summary>
        public DateTimeOffset? LastModifiedTime { get; set; }

        [ForeignKey(nameof(Creator))]
        public string CreatorId { get; set; }
        public User Creator { get; set; }

        [ForeignKey(nameof(Workout))]
        public Guid? WorkoutId { get; set; }
        public Workout? Workout { get; set; }
    }
}
