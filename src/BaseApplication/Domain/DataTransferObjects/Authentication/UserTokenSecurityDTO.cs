using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.DataTransferObjects.Authentication
{
    public class UserTokenSecurityDTO
    {
        public long TokenID { get; set; }
        public Guid TokenGuid { get; set; }
        public int UserID { get; set; }
    }
}
