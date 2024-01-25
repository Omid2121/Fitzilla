using Fitzilla.Models.Data;

namespace Fitzilla.DAL.Repository;

public class PlanRepository(DatabaseContext context) : GenericRepository<Plan>(context)
{
}
