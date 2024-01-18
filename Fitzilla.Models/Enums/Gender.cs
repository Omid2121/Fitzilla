using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fitzilla.Models.Enums;

public enum Gender
{
    /// <summary>
    /// Male gender.
    /// </summary>
    [Display(Name = "Male")] Male,

    /// <summary>
    /// Female gender.
    /// </summary>
    [Display(Name = "Female")] Female
}
