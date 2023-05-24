using System.Linq.Expressions;

namespace Application.Interfaces.Repositories;

public interface IRepository<T>
{
    Task<IQueryable<T>> Get(Expression<Func<T, bool>> expression);
    Task<T> CreateAsync(T entity);
    Task<bool> UpdateAsync(T entity);
    Task<bool> DeleteAsync(Guid Id);
}
