using Fitzilla.Models.Enums;

namespace Fitzilla.Models.Data;

public class Session : EntityDetail
{
    /// <summary>
    /// Boolean value to determine if the session is active.
    /// </summary>
    public bool IsActive { get; set; }

    /// <summary>
    /// The date and time the session was activated.
    /// </summary>
    public DateTimeOffset? ActivatedAt { get; set; }

    /// <summary>
    /// The date and time the session was deactivated.
    /// </summary>
    public DateTimeOffset? DeactivatedAt { get; set; }

    /// <summary>
    /// The relationship between the session and the plan.
    /// </summary>
    public Guid PlanId { get; set; }
    public virtual Plan Plan { get; set; }

    /// <summary>
    /// The relationship between the session and the creator.
    /// </summary>
    public string CreatorId { get; set; }
    public virtual User Creator { get; set; }

    /// <summary>
    /// List of activity types for the session.
    /// </summary>
    public virtual ICollection<ActivityType> ActivityTypes  { get; set; }

    /// <summary>
    /// The relationship between the session and the exercise.
    /// </summary>
    public virtual ICollection<Exercise>? Exercises { get; set; }
}
