using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fitzilla.Core.DTOs
{
    public class CreateExerciseTypeDTO
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public string Description { get; set; }

        public string Icon { get; set; }

        public DateTimeOffset CreationTime { get; set; }

        //TODO: This bool should not effect the database.
        public bool IsChecked { get; set; }

        public string CreatorId { get; set; }
    }

    public class ExerciseTypeDTO : CreateExerciseTypeDTO
    {
        public Guid Id { get; set; }

        public UserDTO Creator { get; set; }

        public virtual IList<ExerciseDTO> Exercises { get; set; }
    }

    public class UpdateExerciseTypeDTO : CreateExerciseTypeDTO
    {
        public DateTimeOffset? LastModifiedTime { get; set; }
    }
}
