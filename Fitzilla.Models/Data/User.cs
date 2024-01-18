using Fitzilla.Models.Enums;
using Microsoft.AspNetCore.Identity;

namespace Fitzilla.Models.Data;

public class User : IdentityUser
{
    /// <summary>
    /// User's first name
    /// </summary>
    public string FirstName { get; set; }

    /// <summary>
    /// User's last name
    public string LastName { get; set; }

    /// <summary>
    /// User's birthdate
    /// </summary>
    public DateTime DateOfBirth { get; set; }

    /// <summary>
    /// User's gender
    /// </summary>
    public Gender Gender { get; set; }

    /// <summary>
    /// User's weight
    /// </summary>
    public double Weight { get; set; }

    /// <summary>
    /// User's height
    /// </summary>
    public double Height { get; set; }

    /// <summary>
    /// Units of measurement(Metric or Imperial)
    /// </summary>
    public Measurement Measurement { get; set; }

    public virtual ICollection<ExerciseTemplate> ExerciseTemplates { get; set; }
    public virtual ICollection<Exercise> Exercises { get; set; }
    public virtual ICollection<Macro> Macros { get; set; }
    public virtual ICollection<Session> Sessions { get; set; }
    public virtual ICollection<Plan> Plans { get; set; }
    public virtual ICollection<Media> Medias { get; set; }
}
