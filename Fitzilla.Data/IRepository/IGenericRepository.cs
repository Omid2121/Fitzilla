using Fitzilla.DAL.Models;
using Fitzilla.Models.Data;
using System.Linq.Expressions;
using X.PagedList;

namespace Fitzilla.DAL.IRepository;

public interface IGenericRepository<T> where T : class, IEntity
{
    Task<IList<T>> GetAll(Expression<Func<T, bool>>? expression = null,
        Func<IQueryable<T>, IOrderedQueryable<T>>? orderBy = null,
        List<string>? includes = null);

    Task<IPagedList<T>> GetPagedList(RequestParams requestParams,
        List<string>? includes = null);

    Task<T> Get(Expression<Func<T, bool>>? expression,
        List<string>? includes = null);

    Task Insert(T entity);
    Task InsertRange(IEnumerable<T>? entities);
    Task Delete(Guid id);
    void DeleteRange(IEnumerable<T>? entities);
    void Update(T entity);
    Task<IList<T>> Search(Expression<Func<T, bool>>? predicate,
        List<string>? includes = null);
}
