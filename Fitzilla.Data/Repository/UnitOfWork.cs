using Fitzilla.DAL.IRepository;
using Microsoft.EntityFrameworkCore.Storage;
using System.Data;

namespace Fitzilla.DAL.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DatabaseContext _context;
        private ExerciseRepository _exercises;
        private ExerciseTemplateRepository _exerciseTemplate;
        private SessionRepository _sessions;
        private PlanRepository _plans;
        private MacroRepository _macros;

        public UnitOfWork(DatabaseContext context)
        {
            _context = context;
        }

        public ExerciseRepository Exercises => 
            _exercises ??= new ExerciseRepository(_context);

        public ExerciseTemplateRepository ExerciseTemplates =>
            _exerciseTemplate ??= new ExerciseTemplateRepository(_context);

        public SessionRepository Sessions =>
            _sessions ??= new SessionRepository(_context);

        public PlanRepository Plans => 
            _plans ??= new PlanRepository(_context);

        public MacroRepository Macros =>
            _macros ??= new MacroRepository(_context);

        public IDbTransaction BeginTransaction()
        {
            var transaction = _context.Database.BeginTransaction();
            return transaction.GetDbTransaction();
        }

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
