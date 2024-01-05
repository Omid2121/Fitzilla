using Fitzilla.Models.Data;

namespace Fitzilla.DAL.Repository
{
    public class MacroRepository : GenericRepository<Macro>
    {
        public MacroRepository(DatabaseContext context) : base(context)
        {
        }
    }
}
