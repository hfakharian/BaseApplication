using Contract.Repositories;
using Microsoft.EntityFrameworkCore;
using Persistence.Contexts;
using Persistence.Exceptions;
using Persistence.Extensions;
using System.Linq.Expressions;

namespace Persistence.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {

        readonly EntityDBContext context;

        public GenericRepository(EntityDBContext context)
        {
            this.context = context;
        }

        public async Task<IEnumerable<T>> GetAll(T entity, Expression<Func<T, T>>? selectionExpression = null, int skip = 0, int take = 50)
        {
            try
            {
                return await context
                .Set<T>()
                .MySelect(selectionExpression)
                .Skip(skip)
                .Take(take)
                .AsNoTracking()
                .ToListAsync();
            }
            catch (Exception ex)
            {
                throw new PersistenceException(ex.Message);
            }
        }

        public async Task<IEnumerable<T>> GetByExpression(Expression<Func<T, bool>> expression, Func<IQueryable<T>, IOrderedQueryable<T>>? orderBy = null, string includeProperties = "", Expression<Func<T, T>>? selectionExpression = null, int skip = 0, int take = 50)
        {
            try
            {
                return await context
                .Set<T>()
                .IncludeProperties(includeProperties)
                .MyWhere(expression)
                .MyOrderBy(orderBy)
                .MySelect(selectionExpression)
                .Skip(skip)
                .Take(take)
                .AsNoTracking()
                .ToListAsync();
            }
            catch (Exception ex)
            {
                throw new PersistenceException(ex.Message);
            }
        }

        public async Task<IEnumerable<T>> GetByExpressionIgnoreQueryFilters(Expression<Func<T, bool>> expression, Func<IQueryable<T>, IOrderedQueryable<T>>? orderBy = null, string includeProperties = "", Expression<Func<T, T>>? selectionExpression = null, int skip = 0, int take = 50)
        {
            try
            {
                return await context
                .Set<T>()
                .IncludeProperties(includeProperties)
                .IgnoreQueryFilters()
                .MyWhere(expression)
                .MyOrderBy(orderBy)
                .MySelect(selectionExpression)
                .Skip(skip)
                .Take(take)
                .AsNoTracking()
                .ToListAsync();
            }
            catch (Exception ex)
            {
                throw new PersistenceException(ex.Message);
            }
        }

        public async Task<T?> FindByID(object id)
        {
            try
            {
                return await context
                .Set<T>()
                .FindAsync(id);
            }
            catch (Exception ex)
            {
                throw new PersistenceException(ex.Message);
            }
        }

        public async Task<T?> FindByExpression(Expression<Func<T, bool>> expression, string includeProperties = "", Expression<Func<T, T>>? selectionExpression = null)
        {
            try
            {
                return await context
                .Set<T>()
                .IncludeProperties(includeProperties)
                .MyWhere(expression)
                .MySelect(selectionExpression)
                .FirstOrDefaultAsync();
            }
            catch (Exception ex)
            {
                throw new PersistenceException(ex.Message);
            }
        }

        public async Task<T?> FindByExpressionIgnoreQueryFilters(Expression<Func<T, bool>> expression, string includeProperties = "", Expression<Func<T, T>>? selectionExpression = null)
        {
            try
            {
                return await context
                .Set<T>()
                .IncludeProperties(includeProperties)
                .IgnoreQueryFilters()
                .MyWhere(expression)
                .MySelect(selectionExpression)
                .FirstOrDefaultAsync();
            }
            catch (Exception ex)
            {
                throw new PersistenceException(ex.Message);
            }
        }

        public async Task<bool> IsExists(Expression<Func<T, bool>> expression)
        {
            try
            {
                return await context
                .Set<T>()
                .AnyAsync(expression);
            }
            catch (Exception ex)
            {
                throw new PersistenceException(ex.Message);
            }
        }

        public async Task Create(T entity)
        {
            try
            {
                await context
                .Set<T>()
                .AddAsync(entity);

                await Task.CompletedTask;
            }
            catch (Exception ex)
            {
                throw new PersistenceException(ex.Message);
            }
        }

        public async Task CreateRange(List<T> entity)
        {
            try
            {
                await context.Set<T>().AddRangeAsync(entity);

                await Task.CompletedTask;
            }
            catch (Exception ex)
            {
                throw new PersistenceException(ex.Message);
            }
        }

        public async Task Update(T entity)
        {
            try
            {
                context.Set<T>().Attach(entity);
                context.Entry(entity).State = EntityState.Modified;

                await Task.CompletedTask;
            }
            catch (Exception ex)
            {
                throw new PersistenceException(ex.Message);
            }
        }

        public async Task UpdateRange(List<T> entity)
        {
            try
            {
                foreach (T e in entity)
                {
                    context.Set<T>().Attach(e);
                    context.Entry(e).State = EntityState.Modified;
                }

                await Task.CompletedTask;
            }
            catch (Exception ex)
            {
                throw new PersistenceException(ex.Message);
            }
        }

        public async Task Delete(T entity)
        {
            try
            {
                if (context.Entry(entity).State == EntityState.Detached)
                {
                    context.Set<T>().Attach(entity);
                }
                context.Set<T>().Remove(entity);

                await Task.CompletedTask;
            }
            catch (Exception ex)
            {
                throw new PersistenceException(ex.Message);
            }
        }

        public async Task DeleteRenge(List<T> entity)
        {
            try
            {
                foreach (T e in entity)
                {
                    if (context.Entry(e).State == EntityState.Detached)
                    {
                        context.Set<T>().Attach(e);
                    }
                }
                context.Set<T>().RemoveRange(entity);

                await Task.CompletedTask;
            }
            catch (Exception ex)
            {
                throw new PersistenceException(ex.Message);
            }
        }


    }
}
