using System.ComponentModel.DataAnnotations;

namespace Fitzilla.Models.Enums
{
    /// <summary>
    /// Enums that decide targeted muscles.
    /// </summary>
    public enum TargetedMuscle
    {
        /// <summary>
        /// The workout targets upper body.
        /// </summary>
        [Display(Name = "Upper Body")] UPPER_BODY,

        /// <summary>
        /// The workout targets lower body.
        /// </summary>
        [Display(Name = "Lower Body")] LOWER_BODY,

        /// <summary>
        /// The workout targets whole body.
        /// </summary>
        [Display(Name = "Whole Body")] WHOLE_BODY,

        /// <summary>
        /// The workout targets chest.
        /// </summary>
        [Display(Name = "Chest")] CHEST,

        /// <summary>
        /// The workout targets back.
        /// </summary>
        [Display(Name = "Back")] BACK,

        /// <summary>
        /// The workout targets shoulders.
        /// </summary>
        [Display(Name = "Shoulders")] SHOULDERS,

        /// <summary>
        /// THE workout targets biceps.
        /// </summary>
        [Display(Name = "Biceps")] BICEPS,

        /// <summary>
        /// The workout targets triceps.
        /// </summary>
        [Display(Name = "Triceps")] TRICEPS,

        /// <summary>
        /// The workout targets forearms.
        /// </summary>  
        [Display(Name = "Forearms")] FOREARMS,

        /// <summary>
        /// The workout targets abs.
        /// </summary>
        [Display(Name = "Abs")] ABS,

        /// <summary>
        /// The workout targets quads.
        /// </summary>
        [Display(Name = "Quads")] QUADS,

        /// <summary>
        /// The workout targets hamstrings.
        /// </summary>
        [Display(Name = "Hamstrings")] HAMSTRINGS,

        /// <summary>
        /// The workout targets calves.
        /// </summary>
        [Display(Name = "Calves")] CALVES,

        /// <summary>
        /// The workout targets glutes.
        /// </summary>
        [Display(Name = "Glutes")] GLUTES
    }
}
