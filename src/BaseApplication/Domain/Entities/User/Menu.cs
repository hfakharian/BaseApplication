using Domain.Entities.Base;
using Domain.Entities.User.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.User
{
    [Table("Menu", Schema = "User")]
    public class Menu : BaseEntity<int>
    {
        public int? MenuParentID { get; set; }
        public MenuType MenuType { get; set; }
        public MenuStatus MenuStatus { get; set; }
        public string? Title { get; set; }
        public string? Url { get; set; }
        public string? Icon { get; set; }
        public int? Sort { get; set; }

        public Menu? MenuParent { get; set; }
        //public virtual ICollection<MenuRole>? MenuRoles { get; set; }
        public virtual List<Role> Roles { get; } = new();

    }
}
