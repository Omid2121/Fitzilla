using Fitzilla.Models.Enums;

namespace Fitzilla.Models.Data;

public class Exercise : EntityDetail
{
    /// <summary>
    /// The number of sets for the exercise. 
    /// Create same amount of exercise records as the number of sets.
    /// </summary>
    public int Set { get; set; }

    /// <summary>
    /// The relationship between the exercise and the session.
    /// </summary>
    public Guid? SessionId { get; set; }
    public virtual Session? Session { get; set; }

    /// <summary>
    /// The relationship between the exercise and the creator.
    /// </summary>
    public string CreatorId { get; set; }
    public virtual User Creator { get; set; }

    /// <summary>
    /// The Equipment required for the exercise.
    /// </summary>
    public Equipment Equipment { get; set; }
    
    /// <summary>
    /// List of targeted muscles for the exercise.
    /// </summary>
    public virtual ICollection<TargetMuscle> TargetMuscles { get; set; }

    /// <summary>
    /// The relationship between the exercise and the exercise record.
    /// </summary>
    public virtual ICollection<ExerciseRecord> ExerciseRecords { get; set; }

    /// <summary>
    /// The relationship between the exercise and the media.
    /// </summary>
    public virtual ICollection<Media>? Medias { get; set; }
}
