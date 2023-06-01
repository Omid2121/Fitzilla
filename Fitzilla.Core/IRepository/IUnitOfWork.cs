using Fitzilla.Core.Repository;
using Fitzilla.Data.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fitzilla.Core.IRepository
{
    public interface IUnitOfWork : IDisposable
    {
        ExerciseRepository Exercises { get; }
        ExerciseTypeRepository ExerciseTypes { get; }
        WorkoutRepository Workouts { get; }
        MacroRepository Macros { get; }
        Task Save();
    }
}
