using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.DataTransferObjects.User
{
    public class UserUnitRoleDTO
    {
        public int? UserID { get; set; }
        public int? UnitID { get; set; }
        public int? RoleID { get; set; }
        public bool? IsAccepted { get; set; }

        public UserDTO? User { get; set; }
        public UnitDTO? Unit { get; set; } 
        public RoleDTO? Role { get; set; }

        public List<RoleDTO>? Roles { get; set; }
    }
}
