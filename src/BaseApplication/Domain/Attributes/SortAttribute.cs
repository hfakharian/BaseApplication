using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Attributes
{
    public class SortAttribute : Attribute
    {
        public readonly int Sort;

        public SortAttribute(int sort)
        {
            Sort = sort;
        }
    }
}
