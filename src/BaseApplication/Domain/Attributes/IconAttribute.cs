using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Attributes
{
    public class IconAttribute : Attribute
    {
        public readonly string Icon;

        public IconAttribute(string icon)
        {
            Icon = icon;
        }
    }
}
