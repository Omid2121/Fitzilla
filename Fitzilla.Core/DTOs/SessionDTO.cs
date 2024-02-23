using Fitzilla.Models.Enums;
using System.ComponentModel.DataAnnotations;

namespace Fitzilla.BLL.DTOs;

public class CreateSessionDTO
{
    [Required]
    public string Title { get; set; }

    public string? Description { get; set; }

    [Required]
    public ICollection<ActivityType> ActivityTypes { get; set; }

    public Guid PlanId { get; set; }
    
    public string CreatorId { get; set; }
}

public class SessionDTO : CreateSessionDTO
{
    public Guid Id { get; set; }

    public DateTimeOffset CreatedAt { get; set; }

    public DateTimeOffset? ModifiedAt { get; set; }
    
    public bool IsActive { get; set; }
    
    public DateTimeOffset? ActivatedAt { get; set; }

    public DateTimeOffset? FinishedAt { get; set; }

    public string PlanTitle { get; set; }

    public string CreatorEmail { get; set; }

    public virtual ICollection<ExerciseDTO>? Exercises { get; set; }
}

public class UpdateSessionDTO
{
    [Required]
    public string Title { get; set; }

    public string? Description { get; set; }

    public DateTimeOffset? ActivatedAt { get; set; }

    public DateTimeOffset? DeactivatedAt { get; set; }

    [Required]
    public ICollection<ActivityType> ActivityTypes { get; set; }

    public Guid PlanId { get; set; }

    public string CreatorId { get; set; }
}
