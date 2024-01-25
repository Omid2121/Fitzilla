namespace Fitzilla.Models.Data;

public class Media : IEntity
{
    /// <summary>
    /// The unique identifier for the media.
    /// </summary>
    public Guid Id { get; set; }

    /// <summary>
    /// The title of the media.
    /// </summary>
    public string Title { get; set; }

    /// <summary>
    /// File path for the media (blob storage).
    /// </summary>
    public string FilePath { get; set; }

    /// <summary>
    /// The relationship between the media and the creator.
    /// </summary>
    public string CreatorId { get; set; }
    public virtual User Creator { get; set; }

    /// <summary>
    /// The relationship between the media and the exercise temaplte.
    /// </summary>
    public virtual ICollection<ExerciseTemplate>? ExerciseTemplates { get; set; }

    /// <summary>
    /// The relationship between the media and the exercise.
    /// </summary>
    public virtual ICollection<Exercise>? Exercises { get; set; }
}
