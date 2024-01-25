namespace Fitzilla.Models.Data;

public interface IEntity
{
    /// <summary>
    /// The unique identifier for the entity.
    /// </summary>
    Guid Id { get; set; }
}
