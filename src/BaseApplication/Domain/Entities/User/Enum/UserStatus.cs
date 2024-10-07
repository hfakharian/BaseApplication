using System.ComponentModel;

namespace Domain.Entities.User.Enum
{
    public enum UserStatus
    {
        [Description("Active")]
        Active = 1,
        [Description("Deactive")]
        Deactive = 2,
        [Description("Block")]
        Block = 3
    }
}
