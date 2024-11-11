using System.Linq.Expressions;

namespace Home_app.Repositories.Interfaces;

public interface IRepositoryBase<T> where T : class
{
    IQueryable<T> GetAll();
    IQueryable<T> GetByCondition(Expression<Func<T, bool>> expression);
    T Create(T entity);
    T Update(T entity);
    T Delete(T entity);
}