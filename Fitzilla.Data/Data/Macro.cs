using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fitzilla.Data.Data
{
    public class Macro : IEntity
    {
        public Guid Id { get; set; }

        /// <summary>
        /// Bulk, Cut, Maintenance
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Calorie Maintenance, Calorie Surplus, Calorie Deficit
        /// </summary>
        public string ConsumeType { get; set; }

        /// <summary>
        /// Sedentary, Moderately active, Very active
        /// </summary>
        public string Intensity { get; set; }

        /// <summary>
        /// Amount of calories
        /// </summary>
        public double Calories { get; set; }

        /// <summary>
        /// Amount of protein
        /// </summary>
        public double Protein { get; set; }

        /// <summary>
        /// Amount of carbohydrates
        /// </summary>
        public double Carbohydrates { get; set; }

        /// <summary>
        /// Amount of fat
        /// </summary>
        public double Fat { get; set; }

        [ForeignKey(nameof(User))]
        public string UserId { get; set; }
        public User User { get; set; }
    }
}
