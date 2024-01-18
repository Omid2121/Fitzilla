using Fitzilla.Models.Data;
using Fitzilla.Models.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fitzilla.BLL.DTOs;

public class CreateSessionDTO
{
    [Required]
    public string Title { get; set; }

    public string? Description { get; set; }

    [Required]
    public TargetedMuscle TargetMuscle { get; set; }

    public Guid PlanId { get; set; }
    
    public string CreatorId { get; set; }
}

public class SessionDTO : CreateSessionDTO
{
    public Guid Id { get; set; }
    
    public string PlanTitle { get; set; }

    public string CreatorEmail { get; set; }

    public virtual ICollection<ExerciseDTO> Exercises { get; set; }
}

public class UpdateSessionDTO : SessionDTO
{
}
