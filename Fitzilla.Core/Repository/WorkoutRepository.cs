using Fitzilla.Data.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fitzilla.Core.Repository
{
    public class WorkoutRepository : GenericRepository<Workout>
    {
        public WorkoutRepository(DatabaseContext context) : base(context)
        {
        }
    }
}
