using AutoMapper;
using Domain.DataTransferObjects.Authentication;
using Domain.DataTransferObjects.User;
using Domain.DataTransferObjects.User.SignIn;
using Domain.Entities.User.Enum;
using Utility.Services.Enum;

namespace Application.Profiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {

            #region User Schema
            CreateMap<Domain.Entities.User.Menu, MenuDTO>().ReverseMap();

            CreateMap<Domain.Entities.User.Role, RoleDTO>().ReverseMap();

            CreateMap<Domain.Entities.User.User, UserDTO>()
               .ForMember(ud => ud.Password, u => u.Ignore())
               .ForMember(ud => ud.UserTypeModel, u => u.MapFrom(x => EnumConvertor.GetModel<UserType>(x.UserType)))
               .ForMember(ud => ud.UserStatusModel, u => u.MapFrom(x => EnumConvertor.GetModel< UserStatus>(x.UserStatus)))
               .ForMember(ud => ud.GenderModel, u => u.MapFrom(x => EnumConvertor.GetModel<Gender>(x.Gender)))
               .ReverseMap();
            CreateMap<Domain.Entities.User.UserDetail, UserDetailDTO>().ReverseMap();

            CreateMap<Domain.Entities.User.Unit, UnitDTO>()
                .ForMember(ud => ud.UnitTypeModel, u => u.MapFrom(x => EnumConvertor.GetModel<UnitType>(x.UnitType)))
                .ForMember(ud => ud.UnitStatusModel, u => u.MapFrom(x => EnumConvertor.GetModel<UnitStatus>(x.UnitStatus)))
                .ReverseMap();
            CreateMap<Domain.Entities.User.UnitDetail, UnitDetailDTO>().ReverseMap();

            CreateMap<Domain.Entities.User.UserUnitRole, UserUnitRoleDTO>().ReverseMap();
            #endregion

        }
    }
}
