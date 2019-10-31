using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Web;

namespace web.GurselFramework.Framework.Helper
{
    public static class ConvertHelper
    {
        public static int ToInt(this object value)
        {
            try
            {
                if (value != null)
                    return Convert.ToInt32(value);
                else
                    return (int)decimal.MinusOne;
            }
            catch
            {
                return (int)decimal.MinusOne;
            }
        }

        public static decimal ToDecimal(this object value)
        {
            try
            {
                if (value != null)
                    return Convert.ToDecimal(value);
                else
                    return (int)decimal.MinusOne;
            }
            catch
            {
                return decimal.MinusOne;
            }
        }

        public static bool ToBoolean(this object value)
        {
            try
            {
                return Convert.ToBoolean(value);
            }
            catch
            {
                return false;
            }
        }

        public static DateTime ToDate(this object value)
        {
            try
            {
                return Convert.ToDateTime(value);
            }
            catch
            {
                return default(DateTime);
            }
        }

        public static IEnumerable<T> ToSplit<T>(this string value, char splitCharacters)
        {
            var returnalue = new List<T>();

            try
            {
                if (value.IsNotNull())
                {
                    var splitValueList = value.Split(splitCharacters).ToList();
                    if (splitValueList.Any())
                    {
                        splitValueList.ForEach(splitValue =>
                        {
                            returnalue.Add((T)Convert.ChangeType(splitValue, typeof(T)));
                        });
                    }
                }
            }
            catch { }

            return returnalue;
        }

        public static string ToCurrencyString(this decimal value, string cultureInfo = "tr-TR")
        {
            return String.Format(new CultureInfo(cultureInfo), "{0:C}", value);
        }

        public static long ToLong(this string value)
        {
            try
            {
                return long.Parse(value);
            }
            catch
            {
                return (int)decimal.MinusOne;
            }
        }

        public static string ConvertToString(this object value)
        {
            if (value != null)
                return value.ToString();
            else
                return "";
        }

        public static float ToFloat(this string value)
        {
            try
            {
                return float.Parse(value.Replace(".", ","));
            }
            catch
            {
                return 0;
            }
        }

        public static string ConvertTurkishCharactersAndToUpper(this string value, bool isUpper = false, bool turkishCharacterReplace = false)
        {
            string returnValue = string.Empty;

            try
            {
                if (value.IsNotNull())
                {
                    var upperOfLowerValue = isUpper ? value.ToUpper() : value;

                    if (turkishCharacterReplace)
                    {
                        upperOfLowerValue = upperOfLowerValue.ReplaceTurkishCharacter();
                    }

                    returnValue = upperOfLowerValue;
                }
            }
            catch { }

            return returnValue;
        }

        public static string ToSubstring(this string value, int startIndex, int length, bool isUpper = false)
        {
            var returnValue = string.Empty;

            try
            {
                if (startIndex != 0)
                {
                    var count = value.Length - startIndex;
                    var subString = value.Substring(startIndex);
                    var substringLength = subString.Length;
                    var subStringTwo = substringLength >= length ? subString.Substring(startIndex, length) : subString;

                    returnValue = substringLength >= count ? subStringTwo : subString;
                }
                else
                {
                    returnValue = value.Length > length ? value.Substring(startIndex, length) : value;
                }

                if (isUpper)
                    returnValue = returnValue.ToUpper();
            }
            catch { returnValue = string.Empty; }

            return returnValue;
        }

        public static string ByteToString(this byte[] value)
        {
            try
            {
                return System.Text.Encoding.UTF8.GetString(value);
            }
            catch (Exception ex)
            {
                return string.Empty;
            }
        }

        public static byte[] ConvertToByteArray(this HttpPostedFileBase file)
        {
            MemoryStream target = new MemoryStream();
            file.InputStream.CopyTo(target);
            return target.ToArray();
        }
    }
}
