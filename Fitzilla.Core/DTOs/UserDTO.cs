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

    public class UserDTO : LoginUserDTO
    {
        public Guid Id { get; set; }

        /// <summary>
        /// User's first name
        /// </summary>
        [Required]
        public string FirstName { get; set; }

        /// <summary>
        /// User's last name
        /// </summary>
        [Required]
        public string LastName { get; set; }

        /// <summary>
        /// User's username
        /// </summary>
        [Required]
        public string UserName { get; set; }

        /// <summary>
        /// User's age calculated based on the user's birth
        /// </summary>
        public int Age { get => (int)Math.Floor(Convert.ToDecimal((DateTime.Now - Birth).TotalDays / 365.25)); }

        /// <summary>
        /// User's birthdate
        /// </summary>
        public DateTime Birth { get; set; }

        [DataType(DataType.PhoneNumber)]
        public string PhoneNumber { get; set; }

        /// <summary>
        /// User's gender
        /// </summary>
        [Required]
        public string Gender { get; set; }

        /// <summary>
        /// User's weight
        /// </summary>
        [Required]
        public double Weight { get; set; }

        /// <summary>
        /// User's height
        /// </summary>
        [Required]
        public double Height { get; set; }

        /// <summary>
        /// Units of measurement(cm, inches, kg, lbs)
        /// </summary>
        public string? Measurement { get; set; }

        public MacroDTO Macro { get; set; }

        public virtual IList<WorkoutDTO> Workouts { get; set; }
    }

    public class LoginResponseDTO
    {
        public string Token { get; set; }
        public UserDTO User { get; set; }
    }
}
