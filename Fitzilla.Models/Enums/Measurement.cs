﻿using System.ComponentModel.DataAnnotations;


namespace Fitzilla.Models.Enums
{
    public enum Measurement
    {
        /// <summary>
        /// Imperial measurement system (lbs, inch, gallon)
        /// </summary>
        [Display(Name = "Imperial")] IMPERIAL,

        /// <summary>
        /// Metric measurement system (Kg, cm, liter)
        ///</summary>
        [Display(Name = "Metric")] METRIC
    }
}