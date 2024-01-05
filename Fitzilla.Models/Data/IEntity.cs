namespace Fitzilla.Models.Data
{
    public interface IEntity
    {
        Guid Id { get; set; }
        DateTimeOffset CreationTime { get; set; }
        DateTimeOffset? LastModifiedTime { get; set; }
    }
}
