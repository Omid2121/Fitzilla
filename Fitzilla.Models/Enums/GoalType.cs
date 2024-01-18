using System.ComponentModel.DataAnnotations;

namespace Fitzilla.Models.Enums;

public enum GoalType
{
    /// <summary>
    /// Mild weight loss of 0.25 kg (0.5 lb) per week. 
    /// </summary>
    [Display(Name = "Mild Weight Loss")] MildWeightLoss,

    /// <summary>
    /// Weight loss of 0.5 kg (1 lb) per week. 
    /// </summary>
    [Display(Name = "Weight Loss")] WeightLoss,

    /// <summary>
    /// Extreme weight loss of 1 kg (2 lb) per week. 
    /// </summary>
    [Display(Name = "Extreme Weight Loss")] ExtremeWeightLoss,

    /// <summary>
    /// Maintain current weight status
    /// </summary>
    [Display(Name = "Maintenance")] Maintenance,

    /// <summary>
    /// Mild weight gain of 0.25 kg (0.5 lb) per week. 
    /// </summary>
    [Display(Name = "Mild Weight Gain")] MildWeightGain,

    /// <summary>
    /// Weight gain of 0.5 kg (1 lb) per week. 
    /// </summary>
    [Display(Name = "Weight Gain")] WeightGain,

    /// <summary>
    /// Extreme weight gain of 1 kg (2 lb) per week. 
    /// </summary>
    [Display(Name = "Extreme Weight Gain")] ExtremeWeightGain
}
