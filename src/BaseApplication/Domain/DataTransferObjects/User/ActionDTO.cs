using Domain.DataTransferObjects.Base;
using Domain.Entities.User.Enum;


namespace Domain.DataTransferObjects.User
{
    public class ActionDTO : BaseEntityDTO<int?>
    {
        public string Title { get; set; }
        public string? Comment { get; set; }
        public bool? Active { get; set; } = false;
    }
}
