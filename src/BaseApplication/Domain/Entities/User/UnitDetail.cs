using Domain.Entities.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.User
{
    [Table("UnitDetail", Schema = "User")]
    public class UnitDetail
    {

        public UnitDetail()
        {
            Address = null;
            Phone = null;
            Image = null;
        }

        public long UnitID { get; set; }
        public string? Address { get; set; }
        public string? Phone { get; set; }
        public string? Image { get; set; }

        public virtual Unit Unit { get; set; }
    }
}
