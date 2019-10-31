using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;

namespace web.GurselFramework.Core.CoreUtilities.Helper
{
    public static class JsonHelper
    {
        public static string ToJson(this object value)
        {
            try
            {
                return JsonConvert.SerializeObject(value, Formatting.Indented, new JsonSerializerSettings { PreserveReferencesHandling = PreserveReferencesHandling.Objects });
            }
            catch
            {
                return string.Empty;
            }
        }

        public static T FromJson<T>(this string json)
        {
            try
            {
                var dateTimeConverter = new IsoDateTimeConverter { DateTimeFormat = "dd.MM.yyyy HH:mm:ss" };

                return JsonConvert.DeserializeObject<T>(json, dateTimeConverter);
            }
            catch (Exception ex)
            {
                return default(T);
            }
        }
    }
}
