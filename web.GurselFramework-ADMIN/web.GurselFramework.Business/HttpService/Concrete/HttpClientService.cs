using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using web.GurselFramework.Business.HttpService.Abstract;
using web.GurselFramework.Business.HttpService.Concrete.Models;
using web.GurselFramework.Core.Aspects.Postsharp.ExceptionAspects;
using web.GurselFramework.Core.Aspects.Postsharp.LogAspects;
using web.GurselFramework.Core.Configuration;
using web.GurselFramework.Core.CrossCuttingConcerns.Logging.Log4Net.Loggers;
using web.GurselFramework.Core.NoSql.Redis;
using web.GurselFramework.Core.NoSql.Redis.Model;
using web.GurselFramework.Framework.Constant;
using web.GurselFramework.Framework.Helper;

namespace web.GurselFramework.Business.HttpService.Concrete
{
    public class HttpClientService<T> : IHttpClientService<T>
    {
        private Parameter _parameters;
        public HttpClientService(Parameter parameters)
        {
            _parameters = parameters;
        }

        [ExceptionLogAspect(typeof(DatabaseLogger))]
        [LogAspect(typeof(DatabaseLogger))]
        public T PostType(string route, dynamic data = default(dynamic), int userId = -1, string computerName = "")
        {
            try
            {
                ServicePointManager.ServerCertificateValidationCallback += (sender, cert, chain, sslPolicyErrors) => true;
                using (var client = new HttpClient())
                {
                    client.DefaultRequestHeaders.Add("OperationUserId", userId.ToString());
                    client.DefaultRequestHeaders.Add("OperationComputerName", computerName);
                    client.DefaultRequestHeaders.Add("Authorization", "Bearer " + _parameters.Token);

                    var response = client.PostAsync(_parameters.ServiceUrl + route, new StringContent(JsonConvert.SerializeObject(data), Encoding.UTF8, "application/json")).Result;

                    var unused = response.StatusCode;
                    if (unused == HttpStatusCode.Unauthorized)
                    {
                        _parameters.Token = string.Empty;

                        var information = GetUserInformation();
                        if (information != null && information.UserId > decimal.Zero)
                        {
                            var token = JsonConvert.DeserializeObject<TokenModel>(HttpTokenService.RequestToken(Config.GetApiUrl(string.Empty), information.Username, CryptoHelper.Decrypt(information.Password), information.IsCustomer));
                            if (token.Error != "error" && token.AccessToken.IsNotNull())
                            {

                                var tokenModel = new TokenModelTemplate
                                {
                                    AccessToken = token.AccessToken,
                                    UserId = token.UserId,
                                    User = token.User
                                };

                                _parameters.Token = token.AccessToken;

                                return PostType(route, data, userId, computerName);
                            }
                        }

                        return default(T);
                    }
                    else
                    {
                        var dateTimeConverter = new IsoDateTimeConverter { DateTimeFormat = "dd.MM.yyyy HH:mm:ss" };
                        return JsonConvert.DeserializeObject<T>(response.Content.ReadAsStringAsync().Result, dateTimeConverter);
                    }
                }
            }
            catch (Exception ex)
            {
                return default(T);
            }
        }

        [ExceptionLogAspect(typeof(DatabaseLogger))]
        [LogAspect(typeof(DatabaseLogger))]
        public T GetType(string route, dynamic data = default(dynamic), int userId = -1, string computerName = "")
        {
            try
            {
                using (var client = new HttpClient())
                {
                    client.DefaultRequestHeaders.Add("OperationUserId", userId.ToString());
                    client.DefaultRequestHeaders.Add("OperationComputerName", computerName);

                    client.DefaultRequestHeaders.Add("Authorization", "Bearer " + _parameters.Token);
                    var response = client.GetAsync(_parameters.ServiceUrl + route + (data != null ? "?" + ToQueryString(data) : default(string)), HttpCompletionOption.ResponseHeadersRead).Result;

                    var unused = response.StatusCode;
                    if (unused == HttpStatusCode.Unauthorized)
                    {
                        _parameters.Token = string.Empty;

                        var information = GetUserInformation();
                        if (information != null && information.UserId > decimal.Zero)
                        {
                            var token = JsonConvert.DeserializeObject<TokenModel>(HttpTokenService.RequestToken(Config.GetApiUrl(string.Empty), information.Username, CryptoHelper.Decrypt(information.Password), information.IsCustomer));
                            if (token.Error != "error" && token.AccessToken.IsNotNull())
                            {
                                var tokenModel = new TokenModelTemplate
                                {
                                    AccessToken = token.AccessToken,
                                    UserId = token.UserId,
                                    User = token.User
                                };

                                _parameters.Token = token.AccessToken;

                                return PostType(route, data, userId, computerName);
                            }
                        }

                        return default(T);
                    }
                    else
                    {
                        var dateTimeConverter = new IsoDateTimeConverter { DateTimeFormat = "dd.MM.yyyy HH:mm:ss" };
                        return JsonConvert.DeserializeObject<T>(response.Content.ReadAsStringAsync().Result, dateTimeConverter);
                    }
                }
            }
            catch (Exception ex)
            {
                return default(T);
            }
        }

        public string FileType(string route, string file)
        {
            ServicePointManager.ServerCertificateValidationCallback += (sender, cert, chain, sslPolicyErrors) => true;
            using (var client = new HttpClient())
            {
                using (var form = new MultipartFormDataContent())
                {
                    var fileStream = File.OpenRead(file);
                    var streamContent = new StreamContent(fileStream);
                    var fileContent = new ByteArrayContent(streamContent.ReadAsByteArrayAsync().Result);
                    fileContent.Headers.ContentType = MediaTypeHeaderValue.Parse("multipart/form-data");
                    form.Add(fileContent, "file", Path.GetFileName(file));
                    //form.Add(fileContent, "image", Path.GetFileName(file));
                    client.DefaultRequestHeaders.Add("Authorization", "Bearer " + _parameters.Token);
                    var response = client.PostAsync(_parameters.ServiceUrl + route, form).Result;
                    var unused = response.StatusCode;
                    return response.Content.ReadAsStringAsync().Result;
                }
            }
        }

        private string ToQueryString(object obj, string separator = ",")
        {
            if (obj == null) throw new ArgumentNullException(nameof(obj));
            var properties = obj.GetType().GetProperties().Where(x => x.CanRead).Where(x => x.GetValue(obj, null) != null).ToDictionary(x => x.Name, x => x.GetValue(obj, null));
            var propertyNames = properties.Where(x => !(x.Value is string) && x.Value is IEnumerable).Select(x => x.Key).ToList();
            foreach (var key in propertyNames)
            {
                var valueType = properties[key].GetType();
                var valueElemType = valueType.IsGenericType ? valueType.GetGenericArguments()[0] : valueType.GetElementType();
                if (valueElemType == null || (!valueElemType.IsPrimitive && valueElemType != typeof(string))) continue;
                var enumerable = properties[key] as IEnumerable;
                properties[key] = string.Join(separator, (enumerable ?? throw new InvalidOperationException()).Cast<object>());
            }
            return string.Join("&", properties.Select(x => string.Concat(Uri.EscapeDataString(x.Key), "=", Uri.EscapeDataString(x.Value.ToString()))));
        }

        public UserInformation GetUserInformation()
        {
            var userIdCookie = CookieHelper.Get(CookieConstants.USER_ID_COOKIE).ToInt();
            if (userIdCookie > 0)
            {
                var redisKey = $"UserCurrentSessionæ{userIdCookie}æ";
                var user = new RedisHelper().Get<TokenModelTemplate>(redisKey);
                if (user != null && user.UserId > decimal.Zero)
                {
                    var information = user.User.FromJson<UserInformation>();
                    if (information != null && information.UserId > decimal.Zero)
                    {
                        return information;
                    }
                }
            }

            return new UserInformation();
        }
    }
}
