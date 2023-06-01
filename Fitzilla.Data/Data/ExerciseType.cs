using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fitzilla.Data.Data
{
    public class ExerciseType : IEntity
    {
        public Guid Id { get; set; }

        ///<summary>
        /// ExerciseType's name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// ExerciseType's description
        /// </summary>
        public string Description { get; set; }

        ///<summary>
        /// ExerciseType's image
        /// </summary>
        public string Icon { get; set; }

        ///<summary>
        /// Exercise's Checkbox's value
        /// </summary>
        [NotMapped]
        public bool IsChecked { get; set; }

        [InverseProperty("ExerciseType")]
        public virtual ICollection<Exercise> Exercises { get; set; }
    }
}
