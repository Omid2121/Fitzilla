using Fitzilla.Models.Data;

namespace Fitzilla.DAL.Repository;

public class MacroRepository(DatabaseContext context) : GenericRepository<Macro>(context)
{
}
