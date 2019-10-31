using System;
using System.ComponentModel;
using System.Linq;
using System.Reflection;

namespace web.GurselFramework.Framework.Helper
{
    public static class EnumHelper
    {
        public static T ToEnum<T>(this string value)
        {
            try
            {
                return (T)Enum.Parse(typeof(T), value);
            }
            catch
            {
                return default(T);
            }
        }

        public static T ToEnum<T>(this int value)
        {
            try
            {
                return (T)Enum.Parse(typeof(T), value.ToString());
            }
            catch
            {
                return default(T);
            }
        }

        public static string Description(this Enum value)
        {
            string description = value.ToString();
            FieldInfo fieldInfo = value.GetType().GetField(description);
            DescriptionAttribute[] attributes = (DescriptionAttribute[])fieldInfo.GetCustomAttributes(typeof(DescriptionAttribute), false);
            if (attributes != null && attributes.Any())
            {
                description = attributes[(int)decimal.Zero].Description;
            }

            return description;
        }
    }
}
