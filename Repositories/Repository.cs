using APICatalogo.Context;
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
        _appDbContext.SaveChanges();
        return entity;  
    }

    public T Delete(T entity)
    {
        _appDbContext.Set<T>().Remove(entity);
        _appDbContext.SaveChanges();
        return entity;
    }

    public T? Get(Expression<Func<T, bool>> predicate)
    {
        return _appDbContext.Set<T>().FirstOrDefault(predicate);  
    }

    public IEnumerable<T> GetAll()
    {
        return _appDbContext.Set<T>().ToList();
    }

    public T Update(T entity)
    {
        _appDbContext.Set<T>().Update(entity);
        _appDbContext.SaveChanges();
        return entity;
    }
}
