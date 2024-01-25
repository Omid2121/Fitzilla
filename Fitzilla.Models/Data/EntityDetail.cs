namespace Fitzilla.Models.Data;

public abstract class EntityDetail : RecordLog
{
    /// <summary>
    /// The title of the entity.
    /// </summary>
    public string Title { get; set; }

    /// <summary>
    /// The description of the entity.
    /// </summary>
    public string? Description { get; set; }
}
