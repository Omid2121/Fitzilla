using Fitzilla.Models.Data;

namespace Fitzilla.DAL.Repository;

public class RatingRepository(DatabaseContext context) : GenericRepository<Rating>(context)
{
}
