using Fitzilla.Models.Data;

namespace Fitzilla.DAL.Repository
{
    public class ExerciseTemplateRepository : GenericRepository<ExerciseTemplate>
    {
        public ExerciseTemplateRepository(DatabaseContext context) : base(context)
        {
        }
    }
}
