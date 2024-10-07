using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utility.Extensions
{
    public static class DateTimeExtensions
    {
        public static long ToUnixTimeSeconds(this DateTime value)
        {
            return ((DateTimeOffset)value).ToUnixTimeSeconds();
        }

    }
}
