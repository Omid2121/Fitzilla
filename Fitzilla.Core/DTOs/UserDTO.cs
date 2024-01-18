﻿using Fitzilla.Models.Data;
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
    public DateTime DateOfBirth { get; set; }

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

    public virtual IList<ExerciseTemplateDTO> ExerciseTemplates { get; set; }
    public virtual IList<ExerciseDTO> Exercises { get; set; }
    public virtual IList<MacroDTO> Macros { get; set; }
    public virtual ICollection<SessionDTO> Sessions { get; set; }
    public virtual IList<PlanDTO> Plans { get; set; }
    public virtual IList<MediaDTO> Images { get; set; }
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
