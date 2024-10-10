using Application.Features.Request.Menu.Queries;
using Application.Wrappers;
using AutoMapper;
using Contract.Repositories;
using Domain.DataTransferObjects.Collection;
using Domain.DataTransferObjects.User;
using Domain.Entities.User;
using SkiaSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.RequestHandler.Menu.Queries
{
    public class GetMenuQueryRequestHandler : IRequestHandlerWrapper<GetMenuQueryRequest, MenuDTO>
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public GetMenuQueryRequestHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }

        public async Task<CollectionResult<MenuDTO>> Handle(GetMenuQueryRequest request, CancellationToken cancellationToken)
        {
            var menu = await unitOfWork.MenuRepository.FindByExpression(
                    w => w.ID == request.MenuID);

            var MenuDTO = mapper.Map<Domain.Entities.User.Menu, MenuDTO>(menu);

            return new CollectionResult<MenuDTO>(true, true, MenuDTO);

        }
    }
}
