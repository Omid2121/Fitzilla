using System.ComponentModel.DataAnnotations;

namespace Fitzilla.BLL.DTOs;

public class CreateExerciseTemplateDTO 
{ 
    [Required]
    public string Title { get; set; }

    public string? Description { get; set; }
    
    public string? CreatorId { get; set; }
}

public class ExerciseTemplateDTO : CreateExerciseTemplateDTO
{
    public Guid Id { get; set; }

    public string? CreatorEmail { get; set; }

    public virtual IList<MediaDTO>? Medias { get; set; }
}

public class UpdateExerciseTemplateDTO : CreateExerciseTemplateDTO
{
}
