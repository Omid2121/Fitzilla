namespace Fitzilla.BLL.DTOs;

public class CreateRatingDTO
{
    public int Value { get; set; }
    public string Comment { get; set; }
    public string CreatorId { get; set; }

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
