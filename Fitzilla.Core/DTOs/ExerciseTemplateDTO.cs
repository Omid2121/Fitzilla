﻿using Fitzilla.Models.Enums;
using System.ComponentModel.DataAnnotations;

namespace Fitzilla.BLL.DTOs;

public class CreateExerciseTemplateDTO 
{ 
    [Required]
    public string Title { get; set; }

    public string? Description { get; set; }

    [Required]
    public virtual ICollection<TargetedMuscle> TargetedMuscles { get; set; }
    
    public string? CreatorId { get; set; }

    public virtual ICollection<MediaDTO>? Medias { get; set; }
}

public class ExerciseTemplateDTO : CreateExerciseTemplateDTO
{
    public Guid Id { get; set; }

    public DateTimeOffset CreatedAt { get; set; }

    public DateTimeOffset? ModifiedAt { get; set; }
    
    public string? CreatorEmail { get; set; }
}

public class UpdateExerciseTemplateDTO : CreateExerciseTemplateDTO
{
}
