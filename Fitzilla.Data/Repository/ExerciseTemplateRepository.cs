using Fitzilla.Models.Data;

namespace Fitzilla.DAL.Repository;

public class ExerciseTemplateRepository(DatabaseContext context) : GenericRepository<ExerciseTemplate>(context)
{
}
