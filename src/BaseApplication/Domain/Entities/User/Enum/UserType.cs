using System.ComponentModel;

namespace Domain.Entities.User.Enum
{
    public enum UserType
    {
        [Description("AD")]
        ActiveDirectory = 1,
        [Description("SYS")]
        System = 2,
        [Description("AD & SYS")]
        ActiveDirectoryAndSystem = 3
    }
}
