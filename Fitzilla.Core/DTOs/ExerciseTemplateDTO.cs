using Fitzilla.Models.Enums;
using System.ComponentModel.DataAnnotations;

namespace Fitzilla.BLL.DTOs;

public class CreateExerciseTemplateDTO 
{ 
    [Required]
    public string Title { get; set; }

    public string? Description { get; set; }

    [Required]
    public Equipment Equipment { get; set; }

    [Required]
    public virtual ICollection<TargetMuscle> TargetMuscles { get; set; }

    [Required] 
    public string CreatorId { get; set; }

    public virtual ICollection<CreateMediaDTO>? Medias { get; set; }
}

public class ExerciseTemplateDTO
{
    public Guid Id { get; set; }

    [Required]
    public string Title { get; set; }

    public string? Description { get; set; }

    [Required]
    public Equipment Equipment { get; set; }

    [Required]
    public DateTimeOffset CreatedAt { get; set; }

    public DateTimeOffset? ModifiedAt { get; set; }

    [Required]
    public virtual IList<TargetMuscle> TargetMuscles { get; set; }

    [Required]
    public string CreatorId { get; set; }
    
    public string CreatorEmail { get; set; }

    public virtual ICollection<MediaDTO>? Medias { get; set; }
}

public class UpdateExerciseTemplateDTO : CreateExerciseTemplateDTO
{
}
