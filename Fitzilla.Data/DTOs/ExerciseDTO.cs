using System.ComponentModel.DataAnnotations;

namespace Fitzilla.DAL.DTOs
{
    public class CreateExerciseDTO
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public string Description { get; set; }
        
        public string Image { get; set; }
        
        [Required]
        public int Set { get; set; }

        [Required]
        public int Rep { get; set; }
        
        [Required]
        public double Weight { get; set; }

        public DateTimeOffset CreationTime { get; set; }

        public Guid? WorkoutId { get; set; }

        public string CreatorId { get; set; }
    }

    public class ExerciseDTO : CreateExerciseDTO
    {
        public Guid Id { get; set; }

        public DateTimeOffset? LastModifiedTime { get; set; }

        public UserDTO Creator { get; set; }
        
        public WorkoutDTO Workout { get; set; }
    }

    public class UpdateExerciseDTO : CreateExerciseDTO
    {
        public DateTimeOffset? LastModifiedTime { get; set; }
    }
}
