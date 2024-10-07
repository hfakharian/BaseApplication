using Domain.DataTransferObjects.Base;

namespace Domain.DataTransferObjects.User
{
    public class RoleDTO : BaseEntityDTO<int?>
    {
        public string? Title { get; set; }
        public string? Comment { get; set; }

        public List<ActionDTO>? Actions { get; set; } = null;
        public List<KeyValuePair<int, string?>>? ActionGroups { get; set; }
    }
}
