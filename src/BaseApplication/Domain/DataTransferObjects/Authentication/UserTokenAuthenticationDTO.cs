using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.DataTransferObjects.Authentication
{
    public class UserTokenAuthenticationDTO
    {
        public Guid? TokenID { get; set; }
        public int? UnitID { get; set; }
        public int? UserID { get; set; }
        public string? Username { get; set; }
    }
}
