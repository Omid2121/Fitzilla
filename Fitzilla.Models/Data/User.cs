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
    /// </summary>
    public string LastName { get; set; }

    /// <summary>
    /// User's birthdate
    /// </summary>
    public DateTimeOffset DateOfBirth { get; set; }

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

    /// <summary>
    /// User's refresh token
    /// </summary>
    public string? RefreshToken { get; set; }

    /// <summary>
    /// Expiry date of the refresh token
    /// </summary>
    public DateTimeOffset RefreshTokenExpiry { get; set; }

    /// <summary>
    /// The relationship between the user and the exercise templates.
    /// </summary>
    public virtual ICollection<ExerciseTemplate>? ExerciseTemplates { get; set; }

    /// <summary>
    /// The relationship between the user and the exercise.
    /// </summary>
    public virtual ICollection<Exercise>? Exercises { get; set; }

    /// <summary>
    /// The relationship between the user and the macro.
    /// </summary>
    public virtual ICollection<Macro>? Macros { get; set; }

    /// <summary>
    /// The relationship between the user and the session.
    /// </summary>
    public virtual ICollection<Session>? Sessions { get; set; }

    /// <summary>
    /// The relationship between the user and the plan.
    /// </summary>
    public virtual ICollection<Plan>? Plans { get; set; }

    /// <summary>
    /// The relationship between the user and the media.
    /// </summary>
    public virtual ICollection<Media>? Medias { get; set; }

    /// <summary>
    /// The relationship between the user and the rating.
    /// </summary>
    public virtual ICollection<Rating>? Ratings { get; set; }
}
