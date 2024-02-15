using Fitzilla.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fitzilla.DAL.Models
{
    public class MacroFilterQuery
    {
        public ICollection<GoalType> goalTypes { get; set; }
        public ICollection<ActivityLevel> ActivityLevels { get; set; }
    }
}
