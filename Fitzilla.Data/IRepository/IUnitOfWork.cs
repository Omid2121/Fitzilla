using Fitzilla.DAL.Repository;

namespace Fitzilla.DAL.IRepository
{
    public interface IUnitOfWork : IDisposable
    {
        ExerciseRepository Exercises { get; }
        ExerciseTemplateRepository ExerciseTemplates { get; }
        WorkoutRepository Workouts { get; }
        MacroRepository Macros { get; }
        Task Save();
    }
}
