using System;
using System.Web;

namespace web.GurselFramework.Framework.Helper
{
    public class CookieHelper
    {
        public static void Set(string key, string value, int expiryDay = 360)
        {
            try
            {
                var cookie = new HttpCookie(key);
                cookie.Value = HttpContext.Current.Server.UrlEncode(value);
                cookie.Expires = DateTime.Now.AddDays(expiryDay);

                HttpContext.Current.Response.Cookies.Add(cookie);
            }
            catch (Exception ex)
            {
                
            }
        }

        public static string Get(string key)
        {
            try
            {
                var cookie = HttpContext.Current.Request.Cookies[key];
                if (cookie != null)
                {
                    return HttpContext.Current.Server.UrlDecode(cookie.Value);
                }

                return string.Empty;
            }
            catch (Exception ex)
            {
                return string.Empty;
            }
        }
    }
}
