using Domain.Entities.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.User
{
    [Table("UserUnitRole", Schema = "User")]
    public class UserUnitRole 
    {
        public long UserID { get; set; }
        public long UnitID { get; set; }
        public int RoleID { get; set; }
        public bool IsAccepted { get; set; }

        public virtual  User User { get; set; }
        public virtual  Unit Unit { get; set; }
        public virtual  Role Role { get; set; }
    }
}
