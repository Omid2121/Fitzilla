
using Fitzilla.Data.Data;

namespace Fitzilla.Core.Repository
{
    public  class ExerciseRepository : GenericRepository<Exercise>
    {
        public ExerciseRepository(DatabaseContext context) : base(context)
        {
        }
    }
}
