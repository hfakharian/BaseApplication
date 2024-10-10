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
    public class GetMenusQueryRequestHandlerTest
    {

        private readonly IMapper mapper;
        private Mock<IUnitOfWork> unitOfWork;

        public GetMenusQueryRequestHandlerTest()
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
            var handler = new GetMenusQueryRequestHandler(unitOfWork.Object, mapper);

            var request = new GetMenusQueryRequest();
            request.CurrentUser = new MockCurrentUser();

            // act
            var result = await handler.Handle(request, CancellationToken.None);

            // assert
            Assert.NotNull(request);
            Assert.NotNull(request.CurrentUser);
            Assert.IsType<CollectionResult<List<MenuDTO>>>(result);
            Assert.NotNull(result);
            Assert.NotNull(result.Result);
            Assert.Equal(result.Result.Count, 3);
        }

    }
}
