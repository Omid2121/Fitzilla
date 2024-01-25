using Fitzilla.Models.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fitzilla.DAL.Repository;

public class SessionRepository(DatabaseContext context) : GenericRepository<Session>(context)
{
}
