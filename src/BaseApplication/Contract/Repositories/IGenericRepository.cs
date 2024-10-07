using System.Linq.Expressions;

namespace Contract.Repositories
{
    public interface IGenericRepository<T> where T : class
    {
        Task<IEnumerable<T>> GetAll(T entity, Expression<Func<T, T>>? selectionExpression = null, int skip = 0, int take = 50);
        Task<IEnumerable<T>> GetByExpression(Expression<Func<T, bool>> expression, Func<IQueryable<T>, IOrderedQueryable<T>>? orderBy = null, string includeProperties = "", Expression<Func<T, T>>? selectionExpression = null, int skip = 0, int take = 50);
        Task<IEnumerable<T>> GetByExpressionIgnoreQueryFilters(Expression<Func<T, bool>> expression, Func<IQueryable<T>, IOrderedQueryable<T>>? orderBy = null, string includeProperties = "", Expression<Func<T, T>>? selectionExpression = null, int skip = 0, int take = 50);
        Task<T?> FindByID(object id);
        Task<T?> FindByExpression(Expression<Func<T, bool>> expression, string includeProperties = "", Expression<Func<T, T>>? selectionExpression = null);
        Task<T?> FindByExpressionIgnoreQueryFilters(Expression<Func<T, bool>> expression, string includeProperties = "", Expression<Func<T, T>>? selectionExpression = null);
        Task<bool> IsExists(Expression<Func<T, bool>> expression);
        Task Create(T entity);
        Task CreateRange(List<T> entity);
        Task Update(T entity);
        Task UpdateRange(List<T> entity);
        Task Delete(T entity);
        Task DeleteRenge(List<T> entity);
    }
}
