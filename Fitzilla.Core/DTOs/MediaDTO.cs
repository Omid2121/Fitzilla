using Fitzilla.Models.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fitzilla.BLL.DTOs
{
    public class CreateMediaDTO
    {
        [Required]
        public string Title { get; set; }

        public string? Description { get; set; }

        public string ImageUrl { get; set; }

        public string? VideoUrl { get; set; }

        public string CreatorId { get; set; }
    }

    public class MediaDTO : CreateMediaDTO
    {
        public Guid Id { get; set; }

        public string CreatorEmail { get; set; }

        public virtual ICollection<ExerciseTemplateDTO> ExerciseTemplates { get; set; }

        public virtual ICollection<ExerciseDTO> Exercises { get; set; }
    }

    public class UpdateMediaDTO : CreateMediaDTO
    {
    }
}
