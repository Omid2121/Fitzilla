using System.ComponentModel.DataAnnotations;

namespace Fitzilla.BLL.DTOs;

public class CreateMediaDTO
{
    [Required]
    public string Title { get; set; }

    public string FilePath { get; set; }

    public string CreatorId { get; set; }
}

public class MediaDTO : CreateMediaDTO
{
    public Guid Id { get; set; }

    public string CreatorEmail { get; set; }

    public virtual ICollection<ExerciseTemplateDTO>? ExerciseTemplates { get; set; }

    public virtual ICollection<ExerciseDTO>? Exercises { get; set; }
}

public class UpdateMediaDTO : CreateMediaDTO
{
}
