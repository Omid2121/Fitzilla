using Fitzilla.Models.Data;

namespace Fitzilla.DAL.Repository
{
    public class PlanRepository : GenericRepository<Plan>
    {
        public PlanRepository(DatabaseContext context) : base(context)
        {
        }
    }
}
