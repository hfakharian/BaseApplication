using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contract.PatternValidation
{
    public static class PatternRegex
    {
        public const string PatternNumericRegex = "^([0-9])*$";
        public const string PatternLongPersianDateRegex = @"^(13)|(14)\d\d[/](0[1-9]|1[012])[/](0[1-9]|[12][0-9]|3[01])$";
        public const string PatternShortPersianDateRegex = @"^\d\d[/](0[1-9]|1[012])[/](0[1-9]|[12][0-9]|3[01])$";
        public const string PatternUrlRegex = "^(https?://)?(([0-9a-z_!~*'().&=+$%-]+: )?[0-9a-z_!~*'().&=+$%-]+@)?(([0-9]{1,3}\\.){3}[0-9]{1,3}|([0-9a-z_!~*'()-]+\\.)*([0-9a-z][0-9a-z-]{0,61})?[0-9a-z]\\.[a-z]{2,6})(:[0-9]{1,4})?((/?)|(/[0-9a-z_!~*'().;?:@&=+$,%#-]+)+/?)$";
        public const string PatternComplexRegex = "^([ئ]|[ء]|[ي]|[ی]|[ه]|[و]|[ن]|[م]|[ل]|[گ]|[ک]|[ق]|[ف]|[غ]|[ع]|[ظ]|[ط]|[ض]|[ص]|[ش]|[س]|[ژ]|[ز]|[ر]|[ذ]|[د]|[خ]|[ح]|[چ]|[ج]|[ث]|[ت]|[پ]|[ب]|[آ]|[ا]|[?]|[ ]|[-]|[_]|[a-zA-Z0-9]|[!]|[@]|[#]|[$]|[%]|[^]|[&]|[*]|[(]|[)]|[+]|[=]|[.]|[,]|[ك]|[ڪ]|[<]|[>]|[,]|[/]|[?]|[\\]|[|]|[{]|[}]|[[]|[]])*$";
        public const string PatternEnglishCharachersRegex = "^([a-zA-Z])*$";
        public const string PatternPersianCharachersRegex = "^([ئ]|[ء]|[ي]|[ی]|[ه]|[و]|[ن]|[م]|[ل]|[گ]|[ک]|[ق]|[ف]|[غ]|[ع]|[ظ]|[ط]|[ض]|[ص]|[ش]|[س]|[ژ]|[ز]|[ر]|[ذ]|[د]|[خ]|[ح]|[چ]|[ج]|[ث]|[ت]|[پ]|[ب]|[آ]|[ا]|[?]|[ ]|[ك]|[ڪ])*$";
        public const string PatternEnglishPersianCharachersRegex = "^([a-zA-Z]|[ئ]|[ء]|[ي]|[ی]|[ه]|[و]|[ن]|[م]|[ل]|[گ]|[ک]|[ق]|[ف]|[غ]|[ع]|[ظ]|[ط]|[ض]|[ص]|[ش]|[س]|[ژ]|[ز]|[ر]|[ذ]|[د]|[خ]|[ح]|[چ]|[ج]|[ث]|[ت]|[پ]|[ب]|[آ]|[ا]|[?]|[ ]|[ك]|[ڪ])*$";
        public const string PatternUserName = @"^(?=.{5,20}$)(?![.])(?!.*[.]{2})[a-zA-Z0-9.]+(?<![.])$";
        public const string PatternPasswordRegexComplex = "^(?=.*[A-Z])(?=.*[!@#$&*])(?=.*[0-9].*[0-9])(?=.*[a-z]).{6}$";
        public const string PatternEnglish = @"^[a-zA-Z0-9\s]*$";
        public const string PatternTokenRegex = @"^[a-zA-Z0-9=+/]*$";
        public const string PatternPersianAddressRegex = "^([ئ]|[ء]|[ي]|[ی]|[ه]|[و]|[ن]|[م]|[ل]|[گ]|[ک]|[ق]|[ف]|[غ]|[ع]|[ظ]|[ط]|[ض]|[ص]|[ش]|[س]|[ژ]|[ز]|[ر]|[ذ]|[د]|[خ]|[ح]|[چ]|[ج]|[ث]|[ت]|[پ]|[ب]|[آ]|[ا]|[?]|[ ]|[-]|[_]|[0-9]|[.]|[,]|[ك]|[ڪ]|[,]|[#]|[/]|[۴]|[۵]|[۶]|[١]|[٢]|[٣]|[٤]|[٥]|[٦]|[٧]|[٨]|[٩]|[٠])*$";
        public const string PatternEnglishAddressRegex = "^([?]|[ ]|[-]|[_]|[a-zA-Z0-9]|[.]|[,]|[#]|[/])*$";
        public const string PatternAddressRegex = "(^([?]|[ ]|[-]|[_]|[a-zA-Z0-9]|[.]|[,]|[#]|[/])*$|(^[ئ]|[ء]|[ي]|[ی]|[ه]|[و]|[ن]|[م]|[ل]|[گ]|[ک]|[ق]|[ف]|[غ]|[ع]|[ظ]|[ط]|[ض]|[ص]|[ش]|[س]|[ژ]|[ز]|[ر]|[ذ]|[د]|[خ]|[ح]|[چ]|[ج]|[ث]|[ت]|[پ]|[ب]|[آ]|[ا]|[?]|[ ]|[-]|[_]|[0-9]|[.]|[,]|[ك]|[ڪ]|[,]|[#]|[/]|[۴]|[۵]|[۶]|[١]|[٢]|[٣]|[٤]|[٥]|[٦]|[٧]|[٨]|[٩]|[٠])*$)";
        public const string PatternPhone = "^0[1-9][0-9]{9}$";
        public const string PatternEmail = @"^([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$";
        public const string PatternMobile = "^[0][9][0-9]{9}$";
        public const string PatternTime = "^([0-1][0-9]|[2][0-3]):([0-5][0-9])$";
        public const string PatternIpAddress = @"\b\d{1,3}\.\d{1,3}\.\d{1,3}\.\d{1,3}\b";
        public const string PatternPassword = "^(?:(?=.*[a-z])(?:(?=.*[A-Z])(?=.*[\\d\\W])|(?=.*\\W)(?=.*\\d))|(?=.*\\W)(?=.*[A-Z])(?=.*\\d)).{8,}$";
    }
}
