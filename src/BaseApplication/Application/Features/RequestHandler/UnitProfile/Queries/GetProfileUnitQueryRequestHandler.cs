using Application.Features.Request.UnitProfile.Queries;
using Application.Features.Request.UserProfile.Queries;
using Application.Wrappers;
using AutoMapper;
using Contract.Repositories;
using Domain.DataTransferObjects.Collection;
using Domain.DataTransferObjects.User;
using Domain.Entities.User.Enum;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utility.Services.Enum;

namespace Application.Features.RequestHandler.UnitProfile.Queries
{
    public class GetProfileUnitQueryRequestHandler : IRequestHandlerWrapper<GetProfileUnitQueryRequest, UnitDTO>
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public GetProfileUnitQueryRequestHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }

        public async Task<CollectionResult<UnitDTO>> Handle(GetProfileUnitQueryRequest request, CancellationToken cancellationToken)
        {
            var unit = await unitOfWork.UnitRepository.FindByExpression(x => x.UnitStatus == UnitStatus.Active && x.ID == request.CurrentUser.AuthUnitId, includeProperties: "UnitDetail");

            if (unit.UnitDetail is null)
                unit.UnitDetail = new Domain.Entities.User.UnitDetail();

            var UnitDTO = mapper.Map<Domain.Entities.User.Unit, UnitDTO>(unit ?? new Domain.Entities.User.Unit());

            UnitDTO!.UnitTypeModels = EnumConvertor.EnumToListModel<UnitType>();
            UnitDTO!.UnitStatusModels = EnumConvertor.EnumToListModel<UnitStatus>();

            return new CollectionResult<UnitDTO>(true, true, UnitDTO);
        }
    }
}
