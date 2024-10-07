using Domain.DataTransferObjects.Base;
using Domain.DataTransferObjects.General;
using Domain.Entities.User.Enum;

namespace Domain.DataTransferObjects.User
{
    public class UserDTO : BaseEntityDTO<int?>
    {
        public UserType UserType { get; set; }
        public BaseEnumModel? UserTypeModel { get; set; }
        public List<BaseEnumModel>? UserTypeModels { get; set; }

        public UserStatus UserStatus { get; set; }
        public BaseEnumModel? UserStatusModel { get; set; }
        public List<BaseEnumModel>? UserStatusModels { get; set; }

        public Gender Gender { get; set; }
        public BaseEnumModel? GenderModel { get; set; }
        public List<BaseEnumModel>? GenderModels { get; set; }

        public string? NationalCode { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? FullName { get { return $"{FirstName} {LastName}"; } }
        public string? Email { get; set; }
        public string? Mobile { get; set; }
        public string? Username { get; set; }

        public string? Password { get; set; }

        public UserDetailDTO? UserDetail { get; set; }

        public RoleDTO? Role { get; set; }

        public CaptchaDTO? Captcha { get; set; }

        //public List<GroupDTO>? Groups { get; set; }

        //public List<UserUnitGroupDTO>? UserUnitGroups { get; set; }

    }
}
