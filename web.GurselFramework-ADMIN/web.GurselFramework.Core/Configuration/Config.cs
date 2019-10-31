using System;
using web.GurselFramework.Framework.Constant;
using web.GurselFramework.Framework.Helper;

namespace web.GurselFramework.Core.Configuration
{
    public class Config
    {
        public static string GetWebSiteUrl(Uri siteurl, string url)
        {
            var webSiteUrl = siteurl.AbsoluteUri;
            var absolutePath = siteurl.AbsolutePath;

            if (absolutePath.StartsWith("/"))
                absolutePath = siteurl.AbsolutePath.Substring(1);

            var indexOf = webSiteUrl.IndexOf(absolutePath);
            if (indexOf > decimal.Zero)
                webSiteUrl = webSiteUrl.Substring(0, indexOf);

            if (!webSiteUrl.Contains("://"))
            {
                webSiteUrl = webSiteUrl.Replace("http:", "http://");
                webSiteUrl = webSiteUrl.Replace("https:", "https://");
            }

            if (webSiteUrl.EndsWith("/") || webSiteUrl.EndsWith(@"\"))
                webSiteUrl = webSiteUrl.Substring(0, webSiteUrl.Length - 1);

            if (url.ConvertToString().StartsWith("/") || url.ConvertToString().StartsWith(@"\"))
                url = url.Substring(1);

            return webSiteUrl + "/" + url;
        }

        public static string GetApiUrl(string url)
        {
            var apiUrl = ConfigHelper.ConfigList["ApiUrl"];
            if (apiUrl.IsNotNull())
            {
                if (url.IsNotNull() && !url.StartsWith("/"))
                    url = "/" + url;

                return apiUrl + url;
            }

            return string.Empty;
        }

        public static string GetConfigValueByKey(string key)
        {
            return ConfigHelper.ConfigList[key];
        }

        public static int SystemUser()
        {
            return ConfigHelper.ConfigList["SystemUserId"].ToInt();
        }

        public static string Email(int customerId)
        {
            return ConfigHelper.ConfigList["DefaultEmail"];
        }

        public static string EmailPassword(int customerId)
        {
            return CryptoHelper.Decrypt(ConfigHelper.ConfigList["DefaultPassword"]);
        }

        public static string RedisHost()
        {
            return ConfigHelper.ConfigList[Constants.REDIS_HOST];
        }

        public static string RedisPassword()
        {
            return ConfigHelper.ConfigList[Constants.REDIS_PASSWORD];
        }

        public static int RedisPort()
        {
            return ConfigHelper.ConfigList[Constants.REDIS_PORT].ToInt();
        }
    }
}
