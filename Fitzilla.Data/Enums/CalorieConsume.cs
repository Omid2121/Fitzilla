using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fitzilla.Data.Enums
{
    /// <summary>
    /// Enums that decide a user's calorie consume
    /// </summary>
    public enum CalorieConsume
    {
        /// <summary>
        /// Maintain current weight status
        /// </summary>
        MAINTENANCE,

        /// <summary>
        /// Increase weight
        /// </summary>
        SURPLUS,

        /// <summary>
        /// Lose current weight 
        /// </summary>
        DEFICIT
    }
}
