using Fitzilla.Models.Enums;
using Microsoft.AspNetCore.Identity;

namespace Fitzilla.Models.Data
{
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
        /// User's age calculated based on the user's birth
        /// </summary>
        public int Age { get => (int)Math.Floor(Convert.ToDecimal((DateTime.Now - Birth).TotalDays / 365.25)); }

        /// <summary>
        /// User's birthdate
        /// </summary>
        public DateTime Birth { get; set; }

        /// <summary>
        /// User's gender
        /// </summary>
        public string Gender { get; set; }

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
        public virtual ICollection<Workout> Workouts { get; set; }
    }
}
