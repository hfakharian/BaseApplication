using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.Product.Enum
{
    public enum CategoryStatus
    {
        [Description("Active")]
        Active = 1,
        [Description("Deactive")]
        Deactive = 2
    }
}
