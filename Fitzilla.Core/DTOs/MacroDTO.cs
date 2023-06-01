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
        public string ConsumeType { get; set; }

        [Required]
        public string Intencity { get; set; }

        public double Calories { get; set; }

        public double Protein { get; set; }

        public double Carbohydrates { get; set; }

        public double Fat { get; set; }

        [Required]
        public string UserId { get; set; }
    }
    public class MacroDTO : CreateMacroDTO
    {
        public Guid Id { get; set; }

        public UserDTO User { get; set; }
    }

    public class UpdateMacroDTO : CreateMacroDTO
    {}
}
