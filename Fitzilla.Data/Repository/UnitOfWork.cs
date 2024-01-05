using Fitzilla.DAL.IRepository;

namespace Fitzilla.DAL.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DatabaseContext _context;
        private ExerciseRepository _exercises;
        private ExerciseTemplateRepository _exerciseTemplate;
        private WorkoutRepository _workouts;
        private MacroRepository _macros;

        public UnitOfWork(DatabaseContext context)
        {
            _context = context;
        }

        public ExerciseRepository Exercises => 
            _exercises ??= new ExerciseRepository(_context);

        public ExerciseTemplateRepository ExerciseTemplates =>
            _exerciseTemplate ??= new ExerciseTemplateRepository(_context);
        
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
