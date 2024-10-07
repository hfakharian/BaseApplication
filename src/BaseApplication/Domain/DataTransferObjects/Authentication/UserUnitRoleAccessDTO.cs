using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.DataTransferObjects.Authentication
{
    public class UserUnitRoleAccessDTO
    {
        public int? UnitID { get; set; }
        public int? UserID { get; set; }
        public int? RoleID { get; set; }
    }
}
