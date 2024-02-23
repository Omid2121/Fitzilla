using System.ComponentModel.DataAnnotations;

namespace Fitzilla.Models.Enums;

public enum Measurement
{
    /// <summary>
    /// Metric measurement system (Kg, cm, liter)
    ///</summary>
    [Display(Name = "Metric")] Metric,
        
    /// <summary>
    /// Imperial measurement system (lbs, inch, gallon)
    /// </summary>
    [Display(Name = "Imperial")] Imperial
}
