using Application.Interfaces.Repositories;
using System.Linq.Expressions;

namespace Infrastructure.Services;

public class Repository<T> : IRepository<T> where T : class
{
    private readonly ICatalogDbContext _catalogDb;

    public Repository(ICatalogDbContext catalogDb)
    {
        _catalogDb = catalogDb;
    }

    public virtual async Task<T> CreateAsync(T entity)
    {
        _catalogDb.Set<T>().Add(entity);
        await _catalogDb.SaveChangesAsync();
        return entity;
    }

    public virtual async Task<bool> DeleteAsync(Guid Id)
    {
        var entity = _catalogDb.Set<T>().Find(Id);
        if (entity != null)
        {
            _catalogDb.Set<T>().Remove(entity);
            await _catalogDb.SaveChangesAsync();
            return true;
        }
        return false;

    }

    public virtual Task<IQueryable<T>> Get(Expression<Func<T, bool>> expression)
    {
        return Task.FromResult(_catalogDb.Set<T>().Where(expression));
    }

    public virtual async Task<bool> UpdateAsync(T entity)
    {
        if (entity != null)
        {
            _catalogDb.Set<T>().Update(entity);
            await _catalogDb.SaveChangesAsync();
            return true;
        }
        return false;
    }
}
