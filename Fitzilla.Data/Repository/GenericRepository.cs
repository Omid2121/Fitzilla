using Fitzilla.DAL.IRepository;
using Fitzilla.DAL.Models;
using Fitzilla.Models.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query.SqlExpressions;
using System.Linq.Expressions;
using X.PagedList;

namespace Fitzilla.DAL.Repository;

public class GenericRepository<T> : IGenericRepository<T> where T : class, IEntity
{
    private readonly DatabaseContext _context;
    private readonly DbSet<T> _dbSet;

    public GenericRepository(DatabaseContext context)
    {
        _context = context;
        _dbSet = _context.Set<T>();
    }

    public async Task Delete(Guid id)
    {
        var entity = await _dbSet.FindAsync(id);
        _dbSet.Remove(entity);
    }

    public void DeleteRange(IEnumerable<T> entities)
    {
        _dbSet.RemoveRange(entities);
    }

    public async Task<T> Get(Expression<Func<T, bool>>? expression, List<string>? includes = null)
    {
        IQueryable<T> query = _dbSet;
        if (includes != null)
        {
            foreach (var includeProperty in includes)
            {
                query = query.Include(includeProperty);
            }
        }
        return await query.AsNoTracking().FirstOrDefaultAsync(expression);
    }

    public async Task<IList<T>> GetAll(Expression<Func<T, bool>>? expression = null,
        Func<IQueryable<T>, IOrderedQueryable<T>>? orderBy = null, List<string>? includes = null)
    {
        IQueryable<T> query = _dbSet;

        if (expression != null)
        {
            query = query.Where(expression);
        }

        if (includes != null)
        {
            foreach (var includeProperty in includes)
            {
                query = query.Include(includeProperty);
            }
        }
        if (orderBy != null)
        {
            query = orderBy(query);
        }
        
        return await query.AsNoTracking().ToListAsync();
    }

    public async Task<IPagedList<T>> GetPagedList(RequestParams requestParams,
        Expression<Func<T, bool>>? expression = null, 
        Func<IQueryable<T>, IOrderedQueryable<T>>? orderBy = null, List<string>? includes = null)
    {
        IQueryable<T> query = _dbSet;

        if (expression != null)
        {
            query = query.Where(expression);
        }

        if (includes != null)
        {
            foreach (var includeProperty in includes)
            {
                query = query.Include(includeProperty);
            }
        }
        if (orderBy != null)
        {
            query = orderBy(query);
        }
        
        return await query.AsNoTracking()
            .ToPagedListAsync(requestParams.PageNumber, requestParams.PageSize);
    }

    public async Task Insert(T entity)
    {
        entity.Id = Guid.NewGuid();
        await _dbSet.AddAsync(entity);
    }

    public async Task InsertRange(IEnumerable<T>? entities)
    {
        entities.Select(entity => entity.Id = Guid.NewGuid());
        await _dbSet.AddRangeAsync(entities);
    }

    public Task<IList<T>> Search(Expression<Func<T, bool>>? predicate, List<string>? includes = null)
    {
        throw new NotImplementedException();
    }

    public void Update(T entity)
    {
        _dbSet.Attach(entity);
        _context.Entry(entity).State = EntityState.Modified;
    }

    public void UpdateRange(IEnumerable<T>? entities)
    {
        _dbSet.AttachRange(entities);
        foreach (var entity in entities)
        {
            _context.Entry(entity).State = EntityState.Modified;
        }
    }
}
