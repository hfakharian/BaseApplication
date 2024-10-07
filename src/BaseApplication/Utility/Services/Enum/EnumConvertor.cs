using Domain.Attributes;
using Domain.DataTransferObjects.Base;
using System.ComponentModel;
using System.Reflection;

namespace Utility.Services.Enum
{
    public static class EnumConvertor
    {
        public static int GetValue<TEnum>(this TEnum enumValue)
        {
            try
            {
                if (enumValue is null) return 0;

                return Convert.ToInt32(System.Enum.Parse(typeof(TEnum), enumValue.ToString() ?? string.Empty));
            }
            catch { return 0; }
        }

        public static string GetName<TEnum>(this TEnum enumValue)
        {
            if (enumValue is null) return string.Empty;

            return enumValue.ToString() ?? string.Empty;
        }

        public static string GetDescription<TEnum>(this TEnum enumValue)
        {
            if (enumValue is null) return string.Empty;

            return enumValue.GetType()
                       .GetMember(enumValue.ToString() ?? string.Empty)
                       .First()
                       .GetCustomAttribute<DescriptionAttribute>()?
                       .Description ?? string.Empty;
        }

        public static int GetSort<TEnum>(this TEnum enumValue)
        {
            if (enumValue is null) return 0;

            return enumValue.GetType()
                       .GetMember(enumValue.ToString() ?? string.Empty)
                       .First()
                       .GetCustomAttribute<SortAttribute>()?
                       .Sort ?? 0;
        }

        public static string GetIcon<TEnum>(this TEnum enumValue)
        {
            if (enumValue is null) return string.Empty;

            return enumValue.GetType()
                       .GetMember(enumValue.ToString() ?? string.Empty)
                       .First()
                       .GetCustomAttribute<IconAttribute>()?
                       .Icon ?? string.Empty;
        }

        public static BaseEnumModel GetModel<TEnum>(this TEnum enumValue)
        {
            try
            {
                if (enumValue is null) return new BaseEnumModel();

                BaseEnumModel baseEnumModel = new BaseEnumModel
                {
                    Value = GetValue<TEnum>(enumValue),
                    Name = GetName<TEnum>(enumValue),
                    Description = GetDescription<TEnum>(enumValue),
                    Sort = GetSort<TEnum>(enumValue),
                    Icon = GetIcon<TEnum>(enumValue),
                };


                return baseEnumModel;
            }
            catch (Exception ex)
            {
                return new BaseEnumModel();
            }
        }


        public static List<KeyValuePair<int, string?>> EnumToList<TEnum>(int[]? skipValues = null)
        {
            var enumList = new List<KeyValuePair<int, string?>>();
            foreach (var d in System.Enum.GetValues(typeof(TEnum))
                    .Cast<TEnum>()
                    .Select(v => new
                    {
                        key = Convert.ToInt32(System.Enum.Parse(typeof(TEnum), v.ToString())),
                        value = (!string.IsNullOrEmpty(GetDescription((TEnum)v)) ? GetDescription((TEnum)v) : GetName((TEnum)v)),
                        sort = GetSort((TEnum)v)
                    })
                    .OrderBy(o => o.sort).ThenBy(o => o.key)
                    .ToList())
            {
                if (skipValues == null)
                {
                    enumList.Add(new KeyValuePair<int, string?>(d.key, d.value));
                }
                else
                {
                    if (!skipValues.Contains(d.key))
                        enumList.Add(new KeyValuePair<int, string?>(d.key, d.value));
                }
            }

            return enumList;
        }

        public static List<BaseEnumModel> EnumToListModel<TEnum>(int[]? skipValues = null)
        {
            var enumList = new List<BaseEnumModel>();
            foreach (var d in System.Enum.GetValues(typeof(TEnum))
                    .Cast<TEnum>()
                    .Select(v => new
                    {
                        key = Convert.ToInt32(System.Enum.Parse(typeof(TEnum), v.ToString() ?? string.Empty)),
                        value = System.Enum.Parse(typeof(TEnum), v.ToString() ?? string.Empty),
                        sort = GetSort((TEnum)v)
                    })
                    .OrderBy(o => o.sort).ThenBy(o => o.key)
                    .ToList())
            {
                if (skipValues == null)
                {
                    enumList.Add(GetModel<TEnum>((TEnum)d.value));
                }
                else
                {
                    if (!skipValues.Contains(d.key))
                        enumList.Add(GetModel<TEnum>((TEnum)d.value));
                }
            }

            return enumList;
        }
    }
}
