using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.Product.Enum
{
    public enum ProductType
    {
        [Description("Sale")]
        Sale = 1,
        [Description("Rent")]
        Rent = 2
    }
}
