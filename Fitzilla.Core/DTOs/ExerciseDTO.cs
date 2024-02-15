using Fitzilla.Models.Enums;
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
    public Equipment Equipment { get; set; }

    [Required]
    public virtual ICollection<TargetMuscle> TargetMuscles { get; set; }

    public Guid? SessionId { get; set; }

    public string CreatorId { get; set; }

    [Required]
    public virtual ICollection<CreateExerciseRecordDTO> ExerciseRecords { get; set; }

    public virtual ICollection<MediaDTO>? Medias { get; set; }
}

public class ExerciseDTO : CreateExerciseDTO
{
    public Guid Id { get; set; }

    public DateTimeOffset CreatedAt { get; set; }

    public DateTimeOffset? ModifiedAt { get; set; }
    
    public string CreatorEmail { get; set; }

    public string SessionTitle { get; set; }

    public virtual ICollection<ExerciseRecordDTO> ExerciseRecords { get; set; }

    public virtual ICollection<MediaDTO>? Medias { get; set; }
}

public class UpdateExerciseDTO : CreateExerciseDTO
{
}
