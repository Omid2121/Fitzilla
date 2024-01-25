using Fitzilla.Models.Data;

namespace Fitzilla.DAL.Repository;

public  class ExerciseRepository(DatabaseContext context) : GenericRepository<Exercise>(context)
{
}
