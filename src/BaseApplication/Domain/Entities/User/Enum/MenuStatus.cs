using System.ComponentModel;

namespace Domain.Entities.User.Enum
{
    public enum MenuStatus
    {
        [Description("Active")]
        Active = 1,
        [Description("Deactive")]
        Deactive = 2
    }
}
