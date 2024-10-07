using Domain.Entities.Base;
using Domain.Entities.User.Enum;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities.User
{

    [Table("Role", Schema = "User")]
    public class Role : BaseEntity<int>
    {
        public Role()
        {
            Title = string.Empty;
            Comment = string.Empty;
            UserUnitRoles = null;
        }

        public RoleType RoleType { get; set; }
        public RoleStatus RoleStatus { get; set; }

        public string Title { get; set; }
        public string? Comment { get; set; }

        public virtual ICollection<UserUnitRole> UserUnitRoles { get; set; }
        //public virtual ICollection<MenuRole>? MenuRoles { get; set; }
        public virtual List<Menu> Menus { get; } = new();

    }
}
