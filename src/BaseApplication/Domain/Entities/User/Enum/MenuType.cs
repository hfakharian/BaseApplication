using System.ComponentModel;

namespace Domain.Entities.User.Enum
{
    public enum MenuType
    {
        [Description("Title")]
        Title = 1,
        [Description("Link")]
        Link = 2
    }
}
