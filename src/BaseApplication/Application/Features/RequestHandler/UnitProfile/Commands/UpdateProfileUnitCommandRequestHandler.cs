using Application.Features.Request.UnitProfile.Commands;
using Application.Wrappers;
using AutoMapper;
using Contract.Repositories;
using Domain.DataTransferObjects.Collection;
using Domain.DataTransferObjects.User;
using Domain.Entities.User.Enum;
using Domain.Entities.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utility.Helper;
using Utility.Services.Enum;


namespace Application.Features.RequestHandler.UnitProfile.Commands
{
    public class UpdateProfileUnitCommandRequestHandler : IRequestHandlerWrapper<UpdateProfileUnitCommandRequest, UnitDTO>
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public UpdateProfileUnitCommandRequestHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }

        public async Task<CollectionResult<UnitDTO>> Handle(UpdateProfileUnitCommandRequest request, CancellationToken cancellationToken)
        {
            var unit = await unitOfWork.UnitRepository.FindByExpression(w => w.ID == request.CurrentUser.AuthUnitId);

            if (unit is null)
                return new CollectionResult<UnitDTO>(true, false,
                    UtilityHelper.AddDangerToCollectionResultMessage("Danger_Unit_Empty"));


            unit.UnitDetail = await unitOfWork.UnitDetailRepository.FindByExpression(w => w.UnitID == unit.ID);

            unit.Title = request.Unit.Title;
            unit.Email = request.Unit.Email;
            unit.Website = request.Unit.Website;


            if (unit.UnitDetail is null)
            {
                unit.UnitDetail = new UnitDetail();
                unit.UnitDetail.UnitID = unit.ID;
                unit.UnitDetail.Address = request.Unit.UnitDetail?.Address;
                unit.UnitDetail.Image = request.Unit.UnitDetail?.Image;
            }
            else
            {
                unit.UnitDetail.Address = request.Unit.UnitDetail?.Address;
                unit.UnitDetail.Image = request.Unit.UnitDetail?.Image;
            }

            await unitOfWork.UnitRepository.Update(unit);
            await unitOfWork.SaveAsync();

            var UnitDTO = mapper.Map<Domain.Entities.User.Unit, UnitDTO>(unit);

            UnitDTO!.UnitTypeModels = EnumConvertor.EnumToListModel<UnitType>();
            UnitDTO!.UnitStatusModels = EnumConvertor.EnumToListModel<UnitStatus>();

            return new CollectionResult<UnitDTO>(true, true, UnitDTO,
                UtilityHelper.AddSuccessToCollectionResultMessage("Success_Unit_Updated"));
        }
    }
}
