using Fitzilla.Models.Enums;
using System.ComponentModel.DataAnnotations;

namespace Fitzilla.DAL.DTOs
{
    public class CreateWorkoutDTO
    {
        [Required]
        public string Name { get; set; }

        public string Description { get; set; }

        [Required]
        public TargetedMuscle TargetMuscle { get; set; }

        public DateTimeOffset CreationTime { get; set; }

        [Required]
        public string CreatorId { get; set; }
    }

    public class WorkoutDTO : CreateWorkoutDTO
    {
        public Guid Id { get; set; }
        
        public UserDTO Creator { get; set; }

        public DateTimeOffset? LastModifiedTime { get; set; }

        public virtual IList<ExerciseDTO> Exercises { get; set; }
    }

    public class UpdateWorkoutDTO : CreateWorkoutDTO
    {
        public DateTimeOffset? LastModifiedTime { get; set; }
    }
}
