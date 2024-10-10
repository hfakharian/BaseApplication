using Application.Features.Request.Menu.Queries;
using Application.Features.RequestHandler.Menu.Queries;
using Application.Profiles;
using ApplicationTest.Mocks;
using ApplicationTest.Mocks.Repository;
using AutoMapper;
using Contract.Repositories;
using Domain.DataTransferObjects.Collection;
using Domain.DataTransferObjects.User;
using Moq;

namespace ApplicationTest.Features.Menu.Queries
{
    public class GetMenuQueryRequestHandlerTest
    {

        private readonly IMapper mapper;
        private Mock<IUnitOfWork> unitOfWork;

        public GetMenuQueryRequestHandlerTest()
        {
            unitOfWork = MockUnitOfWork.GetMockUnitOfWork();

            var mapperConfig = new MapperConfiguration(c =>
            {
                c.AddProfile<MappingProfile>();
            });

            mapper = mapperConfig.CreateMapper();
        }

        [Fact]
        public async Task GetTest()
        {
            // arrange
            var handler = new GetMenuQueryRequestHandler(unitOfWork.Object, mapper);

            var request = new GetMenuQueryRequest();
            request.CurrentUser = new MockCurrentUser();
            request.MenuID = 1;

            // act
            var result = await handler.Handle(request, CancellationToken.None);

            // assert
            Assert.NotNull(request);
            Assert.NotNull(request.CurrentUser);
            Assert.IsType<CollectionResult<MenuDTO>>(result);
            Assert.Equal(result.Result!.ID, 1);
        }

    }
}
