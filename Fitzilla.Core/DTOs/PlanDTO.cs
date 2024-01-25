using Fitzilla.Models.Data;
using Fitzilla.Models.Enums;
using System.ComponentModel.DataAnnotations;

namespace Fitzilla.BLL.DTOs;

public class CreatePlanDTO
{
    [Required]
    public string Title { get; set; }

    public string? Description { get; set; }

    [Required]
    public int SessionsPerWeek { get; set; }

    [Required]
    public int DurationInWeeks { get; set; }

    [Required]
    public string CreatorId { get; set; }
}

public class PlanDTO : CreatePlanDTO
{
    public Guid Id { get; set; }

    public DateTimeOffset CreatedAt { get; set; }

    public DateTimeOffset? ModifiedAt { get; set; }
    
    public string CreatorEmail { get; set; }

    public virtual ICollection<SessionDTO>? Sessions { get; set; }
}

public class UpdatePlanDTO : CreatePlanDTO
{
}
