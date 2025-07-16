using APICatalogo.Context;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace APICatalogo.Repositories;

public class Repository<T> : IRepository<T> where T : class
{

    protected readonly AppDbContext _appDbContext;

    public Repository(AppDbContext appDbContext)
    {
        _appDbContext = appDbContext;   
    }

    public T Create(T entity)
    {
        _appDbContext.Set<T>().Add(entity);
        
        return entity;  
    }

    public T Delete(T entity)
    {
        _appDbContext.Set<T>().Remove(entity);
        
        return entity;
    }

    public T? Get(Expression<Func<T, bool>> predicate)
    {
        return _appDbContext.Set<T>().FirstOrDefault(predicate);  
    }

    public IEnumerable<T> GetAll()
    {
        return _appDbContext.Set<T>().AsNoTracking().ToList();
    }

    public T Update(T entity)
    {
        _appDbContext.Set<T>().Update(entity);
        
        return entity;
    }
}
