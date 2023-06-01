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
        ///<summary>
        /// ExerciseType's name
        /// </summary>
        [Required]
        public string Name { get; set; }

        ///<summary>
        /// ExerciseType's image
        /// </summary>
        public string Icon { get; set; }

        ///<summary>
        /// Exercise's Checkbox's value
        /// </summary>
        [NotMapped]
        public bool IsChecked { get; set; }
    }

    public class ExerciseTypeDTO : CreateExerciseTypeDTO
    {
        public Guid Id { get; set; }

        public virtual IList<ExerciseDTO> Exercises { get; set; }
    }

    public class UpdateExerciseTypeDTO : CreateExerciseTypeDTO
    { }
}
