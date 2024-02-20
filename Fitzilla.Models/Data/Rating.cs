namespace Fitzilla.Models.Data;

public class Rating : RecordLog
{
    /// <summary>
    /// The value of the rating, between 1 and 5.
    /// </summary>
    public int Value { get; set; }

    /// <summary>
    /// The comment for the rating.
    /// </summary>
    public string Comment { get; set; }

    /// <summary>
    /// The relationship between the rating and the creator.
    /// </summary>
    public string CreatorId { get; set; }
    public virtual User Creator { get; set; }

    /// <summary>
    /// The relationship between the rating and the exercise template.
    /// </summary>
    public Guid? ExerciseTemplateId { get; set; }
    public virtual ExerciseTemplate? ExerciseTemplate { get; set; }
}