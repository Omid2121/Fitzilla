using Fitzilla.Data.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fitzilla.Core.DTOs
{
    public class CreateExerciseDTO
    {
        /// <summary>
        /// Weight amount for exercise.
        /// </summary>
        [Required]
        public double Weight { get; set; }

        ///<summary>
        /// Exercise's set
        /// </summary>
        [Required]
        public int Set { get; set; }

        ///<summary>
        /// Exercise's repetition
        /// </summary>
        [Required]
        public int Rep { get; set; }

        [Required]
        public string ExerciseTypeId { get; set; }

        public string WorkoutId { get; set; }
    }

    public class ExerciseDTO : CreateExerciseDTO
    {
        public Guid Id { get; set; }

        public ExerciseTypeDTO ExerciseType { get; set; }

        public WorkoutDTO Workout { get; set; }
    }

    public class UpdateExerciseDTO : CreateExerciseDTO
    {}
}
