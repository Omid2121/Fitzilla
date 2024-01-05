using System.ComponentModel.DataAnnotations;

namespace Fitzilla.DAL.DTOs
{
    public class CreateExerciseTemplateDTO 
    { 
        [Required]
        public string Name { get; set; }

        [Required]
        public string Description { get; set; }

        public string Image { get; set; }

        public DateTimeOffset CreationTime { get; set; }

        public string? CreatorId { get; set; }
    }

    public class ExerciseTemplateDTO : CreateExerciseTemplateDTO
    {
        public Guid Id { get; set; }

        public UserDTO? Creator { get; set; }
    }

    public class UpdateExerciseTemplateDTO : CreateExerciseTemplateDTO
    {
        public DateTimeOffset? LastModifiedTime { get; set; }
    }
}
