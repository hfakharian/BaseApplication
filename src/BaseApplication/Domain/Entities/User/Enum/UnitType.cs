using System.ComponentModel;

namespace Domain.Entities.User.Enum
{
    public enum UnitType
    {
        [Description("Central")]
        Central = 1,
        [Description("Representation")]
        Representation = 2,
        [Description("Branch")]
        Branch = 3
    }
}
