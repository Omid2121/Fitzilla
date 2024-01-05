using System.ComponentModel.DataAnnotations.Schema;

namespace Fitzilla.Models.Data
{
    public class ExerciseTemplate : IEntity
    {
        public Guid Id { get; set; }

        ///<summary>
        /// ExerciseTemplate's name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// ExerciseTemplate's description
        /// </summary>
        public string Description { get; set; }

        ///<summary>
        /// ExerciseTemplate's image
        /// </summary>
        public string Image { get; set; }

        /// <summary>
        /// ExerciseTemplate's creation time.
        /// </summary>
        public DateTimeOffset CreationTime { get; set; }

        /// <summary>
        /// ExerciseTemplate's last modified time.
        /// </summary>
        public DateTimeOffset? LastModifiedTime { get; set; }

        [ForeignKey(nameof(Creator))]
        public string? CreatorId { get; set; }
        public User? Creator { get; set; }
    }
}
