using System.ComponentModel.DataAnnotations;

namespace Fitzilla.Models.Enums
{
    /// <summary>
    /// Enums that decide a user's calorie consume
    /// </summary>
    public enum ConsumeType
    {
        /// <summary>
        /// Maintain current weight status
        /// </summary>
        [Display(Name = "Maintenance")] MAINTENANCE,

        /// <summary>
        /// Increase weight
        /// </summary>
        [Display(Name = "Surplus")] SURPLUS,

        /// <summary>
        /// Lose current weight 
        /// </summary>
        [Display(Name = "Deficit")] DEFICIT
    }
}
