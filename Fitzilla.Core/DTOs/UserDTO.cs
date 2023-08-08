using Fitzilla.Data.Enums;
using System.ComponentModel.DataAnnotations;

namespace Fitzilla.Core.DTOs
{
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

        public string UserName { get; set; }

        public int Age { get => (int)Math.Floor(Convert.ToDecimal((DateTime.Now - Birth).TotalDays / 365.25)); }

        [Required]
        public DateTime Birth { get; set; }

        [DataType(DataType.PhoneNumber)]
        public string PhoneNumber { get; set; }

        [Required]
        public string Gender { get; set; }

        [Required]
        public double Weight { get; set; }

        [Required]
        public double Height { get; set; }

        public Measurement Measurement { get; set; }

        public ICollection<string> Roles { get; set; }
    }

    public class UserDTO : CreateUserDTO
    {
        public string Id { get; set; }

        public virtual  IList<MacroDTO> Macro { get; set; }

        public virtual IList<WorkoutDTO> Workouts { get; set; }
    }

    public class LoginResponseDTO
    {
        public string Token { get; set; }
        public string RefreshToken { get; set; }
        public UserDTO User { get; set; }
    }

    public class UpdateUserDTO : CreateUserDTO
    { }

    public class DeleteUserDTO : LoginUserDTO
    { }

}
