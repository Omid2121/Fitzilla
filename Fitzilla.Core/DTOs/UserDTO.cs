using Fitzilla.Models.Data;
using Fitzilla.Models.Enums;
using System.ComponentModel.DataAnnotations;

namespace Fitzilla.BLL.DTOs;

public class LoginUserDTO
{
    [Required]
    [DataType(DataType.EmailAddress)]
    public string Email { get; set; }

    [Required]
    [DataType(DataType.Password)]
    [StringLength(15, ErrorMessage = "Your password is limited to {2} to {1} characters", MinimumLength = 8)]
    public string Password { get; set; }
}

public class CreateUserDTO : LoginUserDTO
{
    [Required]
    public string FirstName { get; set; }

    [Required]
    public string LastName { get; set; }

    [Required]
    public DateTimeOffset DateOfBirth { get; set; }

    [DataType(DataType.PhoneNumber)]
    public string PhoneNumber { get; set; }

    [Required]
    public Gender Gender { get; set; }

    [Required]
    public double Weight { get; set; }

    [Required]
    public double Height { get; set; }

    public Measurement Measurement { get; set; }
}

public class UserDTO : CreateUserDTO
{
    public string Id { get; set; }
    public string? RefreshToken { get; set; }
    public DateTimeOffset RefreshTokenExpiry { get; set; }

    public virtual ICollection<ExerciseTemplateDTO>? ExerciseTemplates { get; set; }
    public virtual ICollection<ExerciseDTO>? Exercises { get; set; }
    public virtual ICollection<MacroDTO>? Macros { get; set; }
    public virtual ICollection<SessionDTO>? Sessions { get; set; }
    public virtual ICollection<PlanDTO>? Plans { get; set; }
    public virtual ICollection<MediaDTO>? Medias { get; set; }
    public virtual ICollection<RatingDTO>? Ratings { get; set; }
}

public class LoginResponseDTO
{
    public string Token { get; set; }
    public string RefreshToken { get; set; }
    public UserDTO User { get; set; }
}

public class UpdateUserDTO
{
    public string FirstName { get; set; }

    public string LastName { get; set; }

    public DateTime Birth { get; set; }

    [DataType(DataType.PhoneNumber)]
    public string PhoneNumber { get; set; }
    
    [Required]
    public Gender Gender { get; set; }

    [Required]
    public double Weight { get; set; }

    [Required]
    public double Height { get; set; }

    public Measurement Measurement { get; set; }
}

public class DeleteUserDTO : LoginUserDTO
{ }
