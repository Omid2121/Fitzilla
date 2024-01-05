using Fitzilla.Models.Data;

namespace Fitzilla.DAL.Repository
{
    public class WorkoutRepository : GenericRepository<Workout>
    {
        public WorkoutRepository(DatabaseContext context) : base(context)
        {
        }
    }
}
