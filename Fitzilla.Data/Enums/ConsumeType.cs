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
    /// Enums that decide a user's calorie consume
    /// </summary>
    public enum ConsumeType
    {
        /// <summary>
        /// Maintain current weight status
        /// </summary>
        [Display(Name = "Maintenance")] MAINTENANCE,

        /// <summary>
        /// Increase weight
        /// </summary>
        [Display(Name = "Surplus")] SURPLUS,

        /// <summary>
        /// Lose current weight 
        /// </summary>
        [Display(Name = "Deficit")] DEFICIT
    }
}
