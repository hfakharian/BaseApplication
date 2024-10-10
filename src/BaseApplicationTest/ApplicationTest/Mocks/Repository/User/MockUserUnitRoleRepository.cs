using ApplicationTest.Mocks.Data.User;
using Moq;
using System.Linq.Expressions;

using Entity = Domain.Entities.User.UserUnitRole;
using IRepository = Contract.Repositories.User.IUserUnitRoleRepository;

namespace ApplicationTest.Mocks.Repository.User
{
    public class MockUserUnitRoleRepository
    {
        public static Mock<IRepository> GetMockRepository()
        {
            IEnumerable<Entity> eData = MockDataUserUnitRole.getData();

            var mock = new Mock<IRepository>();

            mock.Setup(r => r.GetByExpression(
                It.IsAny<Expression<Func<Entity, bool>>>(),
                It.IsAny<Func<IQueryable<Entity>, IOrderedQueryable<Entity>>>(),
                It.IsAny<string>(),
                It.IsAny<Expression<Func<Entity, Entity>>>(),
                It.IsAny<int>(),
                It.IsAny<int>())).ReturnsAsync(
                (Expression<Func<Entity, bool>>? expression,
                Func<IQueryable<Entity>, IOrderedQueryable<Entity>>? orderBy,
                string includeProperties,
                Expression<Func<Entity, Entity>>? selectionExpression,
                int? skip,
                int? take) =>
                {
                    var query = eData.AsQueryable();

                    if (expression != null)
                        query = query.Where(expression);

                    if (orderBy != null)
                        query = orderBy(query);

                    if (selectionExpression != null)
                        query = query.Select(selectionExpression);

                    query = query.Skip(skip ?? 0).Take(take ?? 50);

                    return query;
                });

            mock.Setup(r => r.FindByExpression(
                It.IsAny<Expression<Func<Entity, bool>>>(),
                It.IsAny<string>(),
                It.IsAny<Expression<Func<Entity, Entity>>>())).ReturnsAsync(
                (Expression<Func<Entity, bool>>? expression,
                string includeProperties,
                Expression<Func<Entity, Entity>>? selectionExpression) =>
                {
                    var query = eData.AsQueryable();

                    if (expression != null)
                        query = query.Where(expression);

                    if (selectionExpression != null)
                        query = query.Select(selectionExpression);

                    return query.FirstOrDefault();
                });

            mock.Setup(r => r.Create(It.IsAny<Entity>()))
                .Returns((Entity data) =>
                {
                    eData.ToList().Add(data);
                    return Task.CompletedTask;
                });


            return mock;
        }
    }
}
