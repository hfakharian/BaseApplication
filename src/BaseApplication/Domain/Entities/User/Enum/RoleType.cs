using System.ComponentModel;

namespace Domain.Entities.User.Enum
{
    public enum RoleType
    {
        [Description("Public")]
        Public = 1,
        [Description("Private")]
        Private = 2
    }
}
