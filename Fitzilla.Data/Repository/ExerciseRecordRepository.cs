using Fitzilla.Models.Data;

namespace Fitzilla.DAL.Repository
{
    public class ExerciseRecordRepository(DatabaseContext context) : GenericRepository<ExerciseRecord>(context)
    {
    }
}
