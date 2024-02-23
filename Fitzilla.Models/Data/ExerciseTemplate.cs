using Fitzilla.Models.Enums;

namespace Fitzilla.Models.Data;

public class ExerciseTemplate : EntityDetail
{
    /// <summary>
    /// The relationship between the exercise temaplte and the creator.
    /// </summary>
    public string CreatorId { get; set; }
    public virtual User Creator { get; set; }

    /// <summary>
    /// The Equipment required for the exercise template.
    /// </summary>
    public Equipment Equipment { get; set; }

    /// <summary>
    /// List of ratings for the exercise template.
    /// </summary>
    public virtual ICollection<Rating>? Ratings { get; set; }

    /// <summary>
    /// List of targeted muscles for the exercise.
    /// </summary>
    public virtual IList<TargetMuscle> TargetMuscles { get; set; }

    /// <summary>
    /// The relationship between the exercise and the media.
    /// </summary>
    public virtual ICollection<Media>? Medias { get; set; }
}
