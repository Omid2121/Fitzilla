using Fitzilla.Data.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fitzilla.Core.DTOs
{
    public class CreateMacroDTO
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public ConsumeType ConsumeType { get; set; }

        [Required]
        public Intensity Intensity { get; set; }

        public double Calories { get; set; }

        public double Protein { get; set; }

        public double Carbohydrates { get; set; }

        public double Fat { get; set; }

        public DateTimeOffset CreationTime { get; set; }

        [Required]
        public string CreatorId { get; set; }
    }
    public class MacroDTO : CreateMacroDTO
    {
        public Guid Id { get; set; }

        public DateTimeOffset? LastModifiedTime { get; set; }

        public UserDTO Creator { get; set; }
    }

    public class UpdateMacroDTO : CreateMacroDTO
    {
        public DateTimeOffset? LastModifiedTime { get; set; }
    }
}