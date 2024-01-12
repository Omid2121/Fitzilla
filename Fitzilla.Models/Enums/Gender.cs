using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fitzilla.Models.Enums
{
    public enum Gender
    {
        [Display(Name = "Male")] MALE,

        [Display(Name = "Female")] FEMALE
    }
}
