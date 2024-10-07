using Domain.Entities.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.User
{
    [Table("MenuRole", Schema = "User")]
    public class MenuRole
    {
        public int MenuID { get; set; }
        public int RoleID { get; set; }

        //public virtual Menu Menu { get; set; }
        //public virtual Role Role { get; set; }
    }
}
