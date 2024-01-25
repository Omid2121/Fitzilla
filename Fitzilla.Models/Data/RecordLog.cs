namespace Fitzilla.Models.Data;

public abstract class RecordLog : IEntity
{
    /// <summary>
    /// The unique identifier for the record.
    /// </summary>
    public Guid Id { get; set; }

    /// <summary>
    /// The date and time the record was created.
    /// </summary>
    public DateTimeOffset CreatedAt { get; set; }

    /// <summary>
    /// The date and time the record was last modified.
    /// </summary>
    public DateTimeOffset? ModifiedAt { get; set; }
}
