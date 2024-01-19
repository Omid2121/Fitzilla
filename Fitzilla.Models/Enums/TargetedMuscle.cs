using System.ComponentModel.DataAnnotations;

namespace Fitzilla.Models.Enums;

public enum TargetedMuscle
{
    /// <summary>
    /// The workout targets upper body.
    /// </summary>
    [Display(Name = "Upper Body")] UpperBody,

    /// <summary>
    /// The workout targets lower body.
    /// </summary>
    [Display(Name = "Lower Body")] LowerBody,

    /// <summary>
    /// The workout targets whole body.
    /// </summary>
    [Display(Name = "Whole Body")] WholeBody,
    
    /// <summary>
    /// The workout targets chest.
    /// </summary>
    [Display(Name = "Chest")] Chest,

    /// <summary>
    /// The workout targets back.
    /// </summary>
    [Display(Name = "Back")] Back,

    /// <summary>
    /// The workout targets shoulders.
    /// </summary>
    [Display(Name = "Shoulders")] Shoulders,

    /// <summary>
    /// THE workout targets biceps.
    /// </summary>
    [Display(Name = "Biceps")] Biceps,

    /// <summary>
    /// The workout targets triceps.
    /// </summary>
    [Display(Name = "Triceps")] Triceps,

    /// <summary>
    /// The workout targets Trapezius.
    /// </summary>
    [Display(Name = "Trapezius")] Trapezius,

    /// <summary>
    /// The workout targets forearms.
    /// </summary>  
    [Display(Name = "Forearms")] Forearms,

    /// <summary>
    /// The workout targets abs.
    /// </summary>
    [Display(Name = "Abs")] Abs,

    /// <summary>
    /// The workout targets quads.
    /// </summary>
    [Display(Name = "Quads")] Quads,

    /// <summary>
    /// The workout targets hamstrings.
    /// </summary>
    [Display(Name = "Hamstrings")] Hamstrings,

    /// <summary>
    /// The workout targets calves.
    /// </summary>
    [Display(Name = "Calves")] Calves,

    /// <summary>
    /// The workout targets glutes.
    /// </summary>
    [Display(Name = "Glutes")] Glutes
}
