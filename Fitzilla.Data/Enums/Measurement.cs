using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fitzilla.Data.Enums
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
