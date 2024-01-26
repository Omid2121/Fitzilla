using System.ComponentModel.DataAnnotations;

namespace Fitzilla.Models.Enums;

public enum TargetMuscle
{
    /// <summary>
    /// The exercise targets upper body.
    /// </summary>
    [Display(Name = "Upper Body")] UpperBody,

    /// <summary>
    /// The exercise targets lower body.
    /// </summary>
    [Display(Name = "Lower Body")] LowerBody,

    /// <summary>
    /// The exercise targets whole body.
    /// </summary>
    [Display(Name = "Whole Body")] WholeBody,

    /// <summary>
    /// The exercise targets chest.
    /// </summary>
    [Display(Name = "Chest")] Chest,

    /// <summary>
    /// The exercise targets lats.
    /// </summary>
    [Display(Name = "Lats")] Lats,

    /// <summary>
    /// The exercise targets middle back.
    /// </summary>
    [Display(Name = "Middle Back")] MiddleBack,

    /// <summary>
    /// The exercise tagets lower back.
    /// </summary>
    [Display(Name = "Lower Back")] LowerBack,

    /// <summary>
    /// The exercise targets shoulders.
    /// </summary>
    [Display(Name = "Shoulders")] Shoulders,

    /// <summary>
    /// THE exercise targets biceps.
    /// </summary>
    [Display(Name = "Biceps")] Biceps,

    /// <summary>
    /// The exercise targets triceps.
    /// </summary>
    [Display(Name = "Triceps")] Triceps,

    /// <summary>
    /// The exercise targets Trapezius.
    /// </summary>
    [Display(Name = "Trapezius")] Trapezius,

    /// <summary>
    /// The exercise targets neck.
    /// </summary>
    [Display(Name = "Neck")] Neck,

    /// <summary>
    /// The exercise targets forearms.
    /// </summary>  
    [Display(Name = "Forearms")] Forearms,

    /// <summary>
    /// The exercise targets abdominals.
    /// </summary>
    [Display(Name = "Abdominals")] Abdominals,

    /// <summary>
    /// The exercise targets core.
    /// </summary>
    [Display(Name = "Core")] Core,

    /// <summary>
    /// The exercise targets quads.
    /// </summary>
    [Display(Name = "Quadriceps")] Quadriceps,

    /// <summary>
    /// The exercise targets Hip Flexors.
    /// </summary>
    [Display(Name = "Hip Flexors")] HipFlexors,

    /// <summary>
    /// The exercise targets Obliques.
    /// </summary>
    [Display(Name = "Obliques")] Obliques,

    /// <summary>
    /// The exercise targets hamstrings.
    /// </summary>
    [Display(Name = "Hamstrings")] Hamstrings,

    /// <summary>
    /// The exercise targets calves.
    /// </summary>
    [Display(Name = "Calves")] Calves,

    /// <summary>
    /// The exercise targets glutes.
    /// </summary>
    [Display(Name = "Glutes")] Glutes,

    /// <summary>
    /// The exercise targets adductors.
    ///     </summary>
    [Display(Name = "Adductors")] Adductors,

    /// <summary>
    /// The exercise targets abductors.
    /// </summary>
    [Display(Name = "Abductors")] Abductors
}
