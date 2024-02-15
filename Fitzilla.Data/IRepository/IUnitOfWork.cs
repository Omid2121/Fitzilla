using Fitzilla.DAL.Repository;
using System.Data;

namespace Fitzilla.DAL.IRepository;

public interface IUnitOfWork : IDisposable
{
    ExerciseRepository Exercises { get; }
    ExerciseRecordRepository ExerciseRecords { get; }
    ExerciseTemplateRepository ExerciseTemplates { get; }
    SessionRepository Sessions { get; }
    PlanRepository Plans { get; }
    MacroRepository Macros { get; }
    RatingRepository Ratings { get; }
    Task Save();
    IDbTransaction BeginTransaction();
}
