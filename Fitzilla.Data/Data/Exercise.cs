using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fitzilla.Data.Data
{
    public class Exercise : IEntity
    {
        public Guid Id { get; set; }

        /// <summary>
        /// Weight amount for exercise.
        /// </summary>
        public double Weight { get; set; }

        ///<summary>
        /// Exercise's set
        /// </summary>
        public int Set { get; set; }

        ///<summary>
        /// Exercise's repetition
        /// </summary>
        public int Rep { get; set; }


        [ForeignKey(nameof(ExerciseType))]
        public string ExerciseTypeId { get; set; }

        public ExerciseType ExerciseType { get; set; }


        [ForeignKey(nameof(Workout))]
        public string WorkoutId { get; set; }

        public Workout Workout { get; set; }
    }
}
