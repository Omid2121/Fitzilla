namespace Fitzilla.Models.Data;

public class Plan : EntityDetail
{
    /// <summary>
    /// The amount of sessions per week for the plan (between 1 to 7).
    /// </summary>
    public int SessionsPerWeek { get; set; }

    /// <summary>
    /// The amount of weeks for the plan (between 1 to 52).
    /// </summary>
    public int DurationInWeeks { get; set; }

    /// <summary>
    /// The relationship between the plan and the creator.
    /// </summary>
    public string CreatorId { get; set; }
    public virtual User Creator { get; set; }

    /// <summary>
    /// The relationship between the plan and the session.
    /// </summary>
    public virtual ICollection<Session>? Sessions { get; set; }
}
