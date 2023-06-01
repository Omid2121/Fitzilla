using Fitzilla.Data.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fitzilla.Core.Repository
{
    public class MacroRepository : GenericRepository<Macro>
    {
        public MacroRepository(DatabaseContext context) : base(context)
        {
        }
    }
}
