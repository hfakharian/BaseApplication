using Domain.Entities.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.DataTransferObjects.User
{
    public class UnitDetailDTO
    {
        public string? Address { get; set; }
        public string? Phone { get; set; }
        public string? Image { get; set; }
    }
}
