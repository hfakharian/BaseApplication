using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utility.Extensions
{
    public static class StringExtensions
    {
        public static int ToInt32(this string value)
        {
            int result = 0;
            int.TryParse(value, out result);
            return result;
        }

        public static long ToInt64(this string value)
        {
            long result = 0;
            long.TryParse(value, out result);
            return result;
        }


        public static Guid ToGuid(this string value)
        {
            Guid result = Guid.Empty;
            Guid.TryParse(value, out result);
            return result;
        }

        public static string ToEFWildCardString(this string? value)
        {
            if (string.IsNullOrWhiteSpace(value))
                return "";

            return $"%{value}%";
        }

    }
}
