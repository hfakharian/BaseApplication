using System.ComponentModel;

namespace Domain.DataTransferObjects.Collection.Enum
{
    public enum ResultMessageType
    {
        [Description("Success")]
        Success = 1,
        [Description("warning")]
        Warning = 2,
        [Description("danger")]
        Danger = 3,
        [Description("info")]
        Info = 4
    }
}
