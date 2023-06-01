using Fitzilla.Data.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fitzilla.Core.Repository
{
    public class ExerciseTypeRepository : GenericRepository<ExerciseType>
    {
        public ExerciseTypeRepository(DatabaseContext context) : base(context)
        {
        }
    }
}
