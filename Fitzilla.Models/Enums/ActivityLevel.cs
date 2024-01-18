using System.ComponentModel.DataAnnotations;

namespace Fitzilla.Models.Enums;

public enum ActivityLevel
{
    /// <summary>
    /// Average and blow active lifestyle (* 1.2)
    /// </summary>
    [Display(Name = "Sedentary")] Sedentary,

    /// <summary>
    /// Slightly active lifestyle (Calories * 1.375)
    /// </summary>
    [Display(Name = "Lightly Active")] LightlyActive,

    /// <summary>
    /// Slightly active lifestyle (Calories * 1.55)
    /// </summary>
    [Display(Name = "Moderately Active")] ModeratelyActive,

    /// <summary>
    /// Vigorously active lifestyle (Calories * 1.725)
    /// </summary>
    [Display(Name = "Vigorously Active")] VigorouslyActive,

    /// <summary>
    /// Very active lifestyle (Calories * 1.9)
    /// </summary>
    [Display(Name = "Very Active")] VeryActive
}
