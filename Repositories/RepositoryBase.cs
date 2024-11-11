using System.Linq.Expressions;
using Home_app.DBContext;
using Home_app.Repositories.Interfaces;

namespace Home_app.Repositories;

public abstract class RepositoryBase<T> : IRepositoryBase<T> where T : class
{
    private HomeAppContext HomeAppContext{ get;}
    
    protected RepositoryBase(HomeAppContext context)
    {
        HomeAppContext = context;
    }
    
    public IQueryable<T> GetAll()
    {
        return HomeAppContext.Set<T>();
    }

    public IQueryable<T> GetByCondition(Expression<Func<T, bool>> expression)
    {
        return HomeAppContext.Set<T>().Where(expression);
    }

    public T Create(T entity)
    {
        return HomeAppContext.Set<T>().Add(entity).Entity;
    }

    public T Update(T entity)
    {
        return HomeAppContext.Set<T>().Update(entity).Entity;
    }

    public T Delete(T entity)
    {
        return HomeAppContext.Set<T>().Remove(entity).Entity;
    }
}