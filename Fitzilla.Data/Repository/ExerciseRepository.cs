using Fitzilla.Models.Data;

namespace Fitzilla.DAL.Repository
{
    public  class ExerciseRepository : GenericRepository<Exercise>
    {
        public ExerciseRepository(DatabaseContext context) : base(context)
        {
        }
    }
}
