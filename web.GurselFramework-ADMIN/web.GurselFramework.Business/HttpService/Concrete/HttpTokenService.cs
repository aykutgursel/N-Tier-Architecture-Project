using System.Collections.Generic;
using System.Net.Http;
using System.Net;
using web.GurselFramework.Framework.Helper;

namespace web.GurselFramework.Business.HttpService.Concrete
{
    public static class HttpTokenService
    {
        public static string RequestToken(string url, string username, string password, bool isCustomer)
        {
            var pairs = new List<KeyValuePair<string, string>>
            {
                new KeyValuePair<string, string>("grant_type","password"),
                new KeyValuePair<string, string>("username"  ,username),
                new KeyValuePair<string, string>("password"  ,password)
            };

            var content = new FormUrlEncodedContent(pairs);

            ServicePointManager.ServerCertificateValidationCallback += (sender, cert, chain, sslPolicyErrors) => true;

            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Add("IsCustomer", isCustomer.ConvertToString());

                var response = client.PostAsync(url + "/token", content).Result;
                var unused = response.StatusCode;
                return response.Content.ReadAsStringAsync().Result;
            }
        }
    }
}
