using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Persistence.Extensions
{
    public static class EfExtensions
    {
        public static System.Linq.IQueryable<T> IncludeProperties<T>(this IQueryable<T> source, string includeProperties) where T : class
        {
            ArgumentNullException.ThrowIfNull("source");

            if (string.IsNullOrEmpty(includeProperties))
                return source;

            foreach (string includeProperty in includeProperties.Split
                (new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
            {
                source = source.Include(includeProperty);
            }

            return source;
        }

        public static System.Linq.IQueryable<T> MySelect<T>(this IQueryable<T> source, Expression<Func<T, T>>? selectionExpression) where T : class
        {
            ArgumentNullException.ThrowIfNull("source");

            if (selectionExpression is null)
                return source;

            return source.Select(selectionExpression);
        }

        public static System.Linq.IQueryable<T> MyWhere<T>(this IQueryable<T> source, Expression<Func<T, bool>>? whereExpression) where T : class
        {
            ArgumentNullException.ThrowIfNull("source");

            if (whereExpression is null)
                return source;

            return source.Where(whereExpression);
        }

        public static System.Linq.IQueryable<T> MyOrderBy<T>(this IQueryable<T> source, Func<IQueryable<T>, IOrderedQueryable<T>>? orderByExpression) where T : class
        {
            ArgumentNullException.ThrowIfNull("source");

            if (orderByExpression is null)
                return source;

            return orderByExpression(source);
        }

    }
}
