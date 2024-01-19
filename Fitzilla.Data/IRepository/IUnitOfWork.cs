using Fitzilla.DAL.Repository;
using Fitzilla.Models.Data;
using System.Data;

namespace Fitzilla.DAL.IRepository;

public interface IUnitOfWork : IDisposable
{
    ExerciseRepository Exercises { get; }
    ExerciseTemplateRepository ExerciseTemplates { get; }
    SessionRepository Sessions { get; }
    PlanRepository Plans { get; }
    MacroRepository Macros { get; }
    Task Save();
    IDbTransaction BeginTransaction();
}
