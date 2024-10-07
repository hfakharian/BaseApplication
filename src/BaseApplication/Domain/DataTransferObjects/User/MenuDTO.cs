using Domain.DataTransferObjects.Base;
using Domain.Entities.User;
using Domain.Entities.User.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.DataTransferObjects.User
{
    public class MenuDTO : BaseEntityDTO<int?>
    {
        public int? MenuParentID { get; set; }
        public MenuType MenuType { get; set; }
        public MenuStatus MenuStatus { get; set; }
        public string? Title { get; set; }
        public string? Url { get; set; }
        public string? Icon { get; set; }
        public int? Sort { get; set; }
    }
}
