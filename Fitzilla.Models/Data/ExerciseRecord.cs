namespace Fitzilla.Models.Data;

public class ExerciseRecord : IEntity
{
    /// <summary>
    /// The unique identifier for the exercise record.
    /// </summary>
    public Guid Id { get; set; }

    /// <summary>
    /// The number of reps for the exercise.
    /// </summary>
    public int Rep { get; set; }

    /// <summary>
    /// The weight for the exercise.
    /// </summary>
    public double Weight { get; set; }


    /// <summary>
    /// The one repetition maximum is the maximum amount of weight you can lift for 1 reps for a given exercise.
    /// </summary>
    public double OneRepMax { get; set; }

    /// <summary>
    /// The relationship between the exercise record and the exercise.
    /// </summary>
    public Guid ExerciseId { get; set; }
    public virtual Exercise Exercise { get; set; }
}
