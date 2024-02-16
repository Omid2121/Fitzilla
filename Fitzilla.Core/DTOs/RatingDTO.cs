using System.ComponentModel.DataAnnotations;

namespace Fitzilla.BLL.DTOs;

public class CreateRatingDTO
{
    [Required]
    public int Value { get; set; }

    [Required]
    public string Comment { get; set; }

    [Required]
    public string CreatorId { get; set; }

    [Required]
    public Guid ExerciseTemplateId { get; set; }
}

public class RatingDTO : CreateRatingDTO
{
    public Guid Id { get; set; }
    public string CreatorEmail { get; set; }
    public string ExerciseTemplateTitle { get; set; }
}

public class UpdateRatingDTO : CreateRatingDTO
{
}
