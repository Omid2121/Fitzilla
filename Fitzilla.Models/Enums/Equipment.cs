using System.ComponentModel.DataAnnotations;

namespace Fitzilla.Models.Enums;

public enum Equipment
{
    /// <summary>
    /// No equipment required.
    /// </summary>
    [Display(Name = "None")] None,

    /// <summary>
    /// Body Weight.
    /// </summary>
    [Display(Name = "Body Weight")] Bodyweight,

    /// <summary>
    /// Barbell equipment.
    /// </summary>
    [Display(Name = "Barbell")] Barbell,

    /// <summary>
    /// Dumbbell equipment.
    /// </summary>
    [Display(Name = "Dumbbell")] Dumbbell,

    /// <summary>
    /// Kettlebell equipment.
    /// </summary>
    [Display(Name = "Kettlebell")] Kettlebell,

    /// <summary>
    /// Bench equipment.
    /// </summary>
    [Display(Name = "Bench")] Bench,

    /// <summary>
    /// Pull-up bar equipment.
    /// </summary>
    [Display(Name = "Pull-up Bar")] PullUpBar,

    /// <summary>
    /// Cable equipment.
    /// </summary>
    [Display(Name = "Cable")] Cable,

    /// <summary>
    /// Machine equipment.
    /// </summary>
    [Display(Name = "Machine")] Machine,

    /// <summary>
    /// Band equipment.
    /// </summary>
    [Display(Name = "Medicine Ball")] MedicineBall,

    /// <summary>
    /// Band equipment.
    /// </summary>
    [Display(Name = "Resistance Band")] ResistanceBand,

    /// <summary>
    /// Foam roller equipment.
    /// </summary>
    [Display(Name = "Foam Roller")] FoamRoller,

    /// <summary>
    /// Wheel equipment
    /// </summary>
    [Display(Name = "Wheel")] Wheel,

    /// <summary>
    /// Bosu ball equipment.
    /// </summary>
    [Display(Name = "Bosu Ball")] BosuBall,

    /// <summary>
    /// Stability ball equipment.
    /// </summary>
    [Display(Name = "Stability Ball")] StabilityBall,

    /// <summary>
    /// TRX equipment.
    /// </summary>
    [Display(Name = "TRX")] TRX,

    /// <summary>
    /// Bar equipment.
    /// </summary>
    [Display(Name = "Bar")] Bar,

    /// <summary>
    /// Plate equipment.
    /// </summary>
    [Display(Name = "Plate")] Plate,

    /// <summary>
    /// Box equipment.
    /// </summary>
    [Display(Name = "Box")] Box,

    /// <summary>
    /// Wall equipment.
    /// </summary>
    [Display(Name = "Wall")] Wall,

    /// <summary>
    /// Rack equipment.
    /// </summary>
    [Display(Name = "Rack")] Rack,

    /// <summary>
    /// Bike equipment.
    /// </summary>
    [Display(Name = "Bike")] Bike,

    /// <summary>
    /// Treadmill equipment.
    /// </summary>
    [Display(Name = "Treadmill")] Treadmill,

    /// <summary>
    /// Rower equipment.
    /// </summary>
    [Display(Name = "Rower")] Rower,

    /// <summary>
    /// Stairs equipment.
    /// </summary>
    [Display(Name = "Stairs")] Stairs,

    /// <summary>
    /// Sled equipment.
    /// </summary>
    [Display(Name = "Sled")] Sled,

    /// <summary>
    /// Sled equipment.
    /// </summary>
    [Display(Name = "Ski Erg")] SkiErg,

    /// <summary>
    /// Prowler equipment.
    /// </summary>
    [Display(Name = "Prowler")] Prowler,

    /// <summary>
    /// Squat rack equipment.
    /// </summary>
    [Display(Name = "Squat Rack")] SquatRack,

    /// <summary>
    /// Dip station equipment.
    /// </summary>
    [Display(Name = "Dip Station")] DipStation,

    /// <summary>
    /// Other equipment.
    /// </summary>
    [Display(Name = "Other")] Other
}
