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
        [Required]
        public double Weight { get; set; }

        [Required]
        public int Set { get; set; }

        [Required]
        public int Rep { get; set; }

        public DateTimeOffset CreationTime { get; set; }

        [Required]
        public Guid? ExerciseTypeId { get; set; }

        public Guid? WorkoutId { get; set; }

        public string CreatorId { get; set; }
    }

    public class ExerciseDTO : CreateExerciseDTO
    {
        public Guid Id { get; set; }

        public DateTimeOffset? LastModifiedTime { get; set; }

        public UserDTO Creator { get; set; }

        public ExerciseTypeDTO ExerciseType { get; set; }

        public WorkoutDTO Workout { get; set; }
    }

    public class UpdateExerciseDTO : CreateExerciseDTO
    {
        public DateTimeOffset? LastModifiedTime { get; set; }
    }
}
