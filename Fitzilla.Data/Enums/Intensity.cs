using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Fitzilla.Data.Enums
{
    /// <summary>
    /// Enums that decide a user's life intensity
    /// </summary>
    public enum Intensity
    {
        /// <summary>
        /// Average and blow active lifestyle
        /// </summary>
        [Display(Name = "Sedentary")] SEDENTARY,

        /// <summary>
        /// Slightly active lifestyle
        /// </summary>
        [Display(Name = "Lightly Active")] LIGHTLY_ACTIVE,

        /// <summary>
        /// Slightly active lifestyle
        /// </summary>
        [Display(Name = "Moderately Active")] MODERATELY_ACTIVE,

        /// <summary>
        /// Vigorously active lifestyle
        /// </summary>
        [Display(Name = "Vigorously Active")] VIGOROUSLY_ACTIVE,

        /// <summary>
        /// Very active lifestyle
        /// </summary>
        [Display(Name = "Very Active")] VERY_ACTIVE
    }
}
