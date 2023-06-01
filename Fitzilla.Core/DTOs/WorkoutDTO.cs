using Fitzilla.Data.Data;
using Fitzilla.Data.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fitzilla.Core.DTOs
{
    public class CreateWorkoutDTO
    {
        ///<summary>
        /// Workout's name
        /// </summary>
        [Required]
        public string Name { get; set; }

        /// <summary>
        /// Custom note for workout.
        /// </summary>
        [NotMapped]
        public string Note { get; set; }

        /// <summary>
        /// Workout's targeted group muscle.
        /// </summary>
        public TargetMuscle TargetMuscle { get; set; }

        ///<summary>
        /// Workout's foreignKey
        /// </summary>
        public string UserId { get; set; }
    }

    public class WorkoutDTO : CreateWorkoutDTO
    {
        public Guid Id { get; set; }

        /// <summary>
        /// Related User instance.
        /// </summary>
        public User User { get; set; }

        public virtual IList<ExerciseDTO> Exercises { get; set; }

    }

    public class UpdateWorkoutDTO : CreateWorkoutDTO
    {}
}
