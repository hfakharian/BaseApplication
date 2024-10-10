using Application.Features.Request.Menu.Queries;
using Application.Features.Request.UserUnitRole.Queries;
using Application.Features.RequestHandler.Menu.Queries;
using Application.Features.RequestHandler.UserUnitRole.Queries;
using Application.Profiles;
using ApplicationTest.Mocks;
using ApplicationTest.Mocks.Repository;
using AutoMapper;
using Contract.Repositories;
using Domain.DataTransferObjects.Collection;
using Domain.DataTransferObjects.User;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationTest.Features.UserUnitRole.Queries
{
    public class GetUserUnitRoleQueryRequestHandlerTest
    {
        private readonly IMapper mapper;
        private Mock<IUnitOfWork> unitOfWork;

        public GetUserUnitRoleQueryRequestHandlerTest()
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
            var handler = new GetUserUnitRoleQueryRequestHandler(unitOfWork.Object, mapper);

            var request = new GetUserUnitRoleQueryRequest();
            request.CurrentUser = new MockCurrentUser();
            request.UserID = 2;

            // act
            var result = await handler.Handle(request, CancellationToken.None);

            // assert
            Assert.NotNull(request);
            Assert.NotNull(request.CurrentUser);
            Assert.IsType<CollectionResult<UserUnitRoleDTO>>(result);
            Assert.NotNull(result);
            Assert.NotNull(result.Result);
            Assert.Equal(result.Result.UserID, 2);
        }
    }
}
