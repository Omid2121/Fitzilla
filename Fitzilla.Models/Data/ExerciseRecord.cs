namespace Fitzilla.Models.Data;

public class ExerciseRecord : IEntity
{
    /// <summary>
    /// The unique identifier for the exercise record.
    /// </summary>
    public Guid Id { get; set; }

    /// <summary>
    /// The number of sets for the exercise.
    /// </summary>
    public int Set { get; set; }

    /// <summary>
    /// The number of reps for the exercise.
    /// </summary>
    public int Rep { get; set; }

    /// <summary>
    /// The weight for the exercise.
    /// </summary>
    public double Weight { get; set; }

    /// <summary>
    /// The relationship between the exercise record and the exercise.
    /// </summary>
    public Guid ExerciseId { get; set; }
    public virtual Exercise Exercise { get; set; }
}
