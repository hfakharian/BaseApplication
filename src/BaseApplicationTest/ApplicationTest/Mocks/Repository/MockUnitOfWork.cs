using ApplicationTest.Mocks.Repository.User;
using Contract.Repositories;
using Moq;

namespace ApplicationTest.Mocks.Repository
{
    public class MockUnitOfWork
    {
        public static Mock<IUnitOfWork> GetMockUnitOfWork()
        {
            var mock = new Mock<IUnitOfWork>();

            mock.Setup(x => x.MenuRepository).Returns(MockMenuRepository.GetMockRepository().Object);

            mock.Setup(x => x.RoleRepository).Returns(MockRoleRepository.GetMockRepository().Object);
            mock.Setup(x => x.UserUnitRoleRepository).Returns(MockUserUnitRoleRepository.GetMockRepository().Object);


            return mock;
        }

    }
}
