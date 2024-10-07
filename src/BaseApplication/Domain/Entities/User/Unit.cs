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

    [Table("Unit", Schema = "User")]
    public class Unit : BaseEntity<long>
    {
        public Unit()
        {
            UnitType = UnitType.Central;
            UnitStatus = UnitStatus.Active;
            Comment = null;
            Website = null;
            Email = null;
        }

        public long? UnitParentID { get; set; }

        public UnitType UnitType { get; set; }
        public UnitStatus UnitStatus { get; set; }
        public string Title { get; set; }
        public string? Comment { get; set; }
        public string? Website { get; set; }
        public string? Email { get; set; }


        public Unit? UnitParent { get; set; }
        public virtual UnitDetail? UnitDetail { get; set; }
        public virtual ICollection<UserUnitRole>? UserUnitRoles { get; set; }

    }
}
