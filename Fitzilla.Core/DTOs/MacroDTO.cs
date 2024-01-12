using Fitzilla.Models.Enums;
using System.ComponentModel.DataAnnotations;

namespace Fitzilla.BLL.DTOs
{
    public class CreateMacroDTO
    {
        [Required]
        public string Title { get; set; }
        
        public string? Description { get; set; }

        [Required]
        public ConsumeType ConsumeType { get; set; }

        [Required]
        public Intensity Intensity { get; set; }

        [Required]
        public double Calories { get; set; }

        [Required]
        public double Protein { get; set; }

        [Required]
        public double Carbohydrates { get; set; }

        [Required]
        public double Fat { get; set; }

        [Required]
        public string CreatorId { get; set; }
    }
    public class MacroDTO : CreateMacroDTO
    {
        public Guid Id { get; set; }

        public string CreatorEmail { get; set; }
    }

    public class UpdateMacroDTO : CreateMacroDTO
    {
    }
}