using Fitzilla.Core.IRepository;
using Fitzilla.Data.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fitzilla.Core.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DatabaseContext _context;
        private ExerciseRepository _exercises;
        private ExerciseTypeRepository _exerciseTypes;
        private WorkoutRepository _workouts;
        private MacroRepository _macros;

        public UnitOfWork(DatabaseContext context)
        {
            _context = context;
        }

        public ExerciseRepository Exercises => 
            _exercises ??= new ExerciseRepository(_context);

        public ExerciseTypeRepository ExerciseTypes => 
            _exerciseTypes ??= new ExerciseTypeRepository(_context);

        public WorkoutRepository Workouts => 
            _workouts ??= new WorkoutRepository(_context);

        public MacroRepository Macros =>
            _macros ??= new MacroRepository(_context);

        public void Dispose()
        {
            _context.Dispose();
            GC.SuppressFinalize(this);
        }

        public async Task Save()
        {
            await _context.SaveChangesAsync();
        }
    }
}
