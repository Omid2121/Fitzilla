using System.ComponentModel.DataAnnotations;

namespace Fitzilla.BLL.DTOs;

public class CreateExerciseDTO
{
    [Required]
    public string Title { get; set; }

    public string? Description { get; set; }
    
    [Required]
    public int Set { get; set; }

    [Required]
    public int Rep { get; set; }
    
    [Required]
    public double Weight { get; set; }

    public Guid? SessionId { get; set; }

    public string CreatorId { get; set; }
}

public class ExerciseDTO : CreateExerciseDTO
{
    public Guid Id { get; set; }

    public string CreatorEmail { get; set; }

    public string SessionTitle { get; set; }

    public virtual IList<MediaDTO>? Medias { get; set; }
}

public class UpdateExerciseDTO : CreateExerciseDTO
{
}
