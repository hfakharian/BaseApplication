using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Contract.PatternValidation
{
    public static class PatternValidator
    {
        public static bool IsNumber(this string data)
        {
            return !string.IsNullOrWhiteSpace(data) && data.All(char.IsDigit);
        }

        public static bool IsValidPatternRegex(this string? inputData, string validationPattern, RegexOptions regexOptions = RegexOptions.None, bool isNullable = false)
        {
            if (string.IsNullOrWhiteSpace(inputData))
            {
                return isNullable;
            }

            return Regex.IsMatch(inputData, validationPattern, regexOptions);
        }
    }
}
