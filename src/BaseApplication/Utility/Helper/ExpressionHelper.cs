using System.Linq.Expressions;

namespace Utility.Helper
{
    public static class ExpressionHelper
    {
        public static Expression<Func<TSource, TDestination>> AndExpression<TSource, TDestination>(Expression<Func<TSource, TDestination>>? e1, Expression<Func<TSource, TDestination>>? e2)
        {
            if (e1 is null && e2 is null)
            {
                throw new ArgumentNullException("source");
            }

            if (e1 is null)
                return e2!;

            if (e2 is null)
                return e1!;

            return Expression.Lambda<Func<TSource, TDestination>>(Expression.AndAlso(
                new SwapVisitor(e1.Parameters[0], e2.Parameters[0]).Visit(e1.Body),
                e2.Body), e2.Parameters);
        }

        public static Expression<Func<TSource, TDestination>> OrExpression<TSource, TDestination>(Expression<Func<TSource, TDestination>>? e1, Expression<Func<TSource, TDestination>>? e2)
        {
            if (e1 is null && e2 is null)
            {
                throw new ArgumentNullException("source");
            }

            if (e1 is null)
                return e2!;

            if (e2 is null)
                return e1!;

            return Expression.Lambda<Func<TSource, TDestination>>(Expression.OrElse(
                new SwapVisitor(e1.Parameters[0], e2.Parameters[0]).Visit(e1.Body),
                e2.Body), e2.Parameters);
        }

        private class SwapVisitor : ExpressionVisitor
        {
            private readonly Expression from, to;
            public SwapVisitor(Expression from, Expression to)
            {
                this.from = from;
                this.to = to;
            }
            public override Expression Visit(Expression node)
            {
                return node == from ? to : base.Visit(node);
            }
        }
    }
}
