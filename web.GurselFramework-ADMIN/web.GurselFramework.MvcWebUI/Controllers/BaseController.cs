using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using web.GurselFramework.Business.HttpService.Abstract;
using web.GurselFramework.Business.HttpService.Concrete;
using web.GurselFramework.Business.HttpService.Concrete.Models;
using web.GurselFramework.Core.Configuration;
using web.GurselFramework.Core.NoSql.Redis;
using web.GurselFramework.Core.NoSql.Redis.Model;
using web.GurselFramework.Framework.Helper;
using web.GurselFramework.MvcWebUI.Business;

namespace web.GurselFramework.MvcWebUI.Controllers
{
    public class BaseController : Controller
    {
        public string ComputerName
        {
            get
            {
                try
                {
                    IPAddress myIP = IPAddress.Parse(Request.UserHostAddress);
                    IPHostEntry GetIPHost = Dns.GetHostEntry(myIP);
                    List<string> compName = GetIPHost.HostName.ToString().Split('.').ToList();
                    return compName.FirstOrDefault();
                }
                catch
                {
                    try
                    {
                        return System.Environment.MachineName;
                    }
                    catch
                    {
                        try
                        {
                            return System.Net.Dns.GetHostName();
                        }
                        catch
                        {
                            return Request.UserHostAddress;
                        }
                    }
                }

            }
        }

        protected IHttpClientService<T> ClientService<T>()
        {
            var redisKey = $"*UserCurrentSessionæ{GurselFrameworkSession.UserId}æ*";
            var data = new RedisHelper().RedisGet<TokenModelTemplate>(new RedisRequestTemplate { RedisKey = redisKey });
            if (data != null && data.AccessToken.IsNotNull())
            {
                return new HttpClientService<T>(new Parameter()
                {
                    ServiceUrl = Config.GetApiUrl(string.Empty),
                    Token = data.AccessToken
                });
            }
            else
            {
                return new HttpClientService<T>(new Parameter()
                {
                    ServiceUrl = Config.GetApiUrl(string.Empty),
                    Token = string.Empty
                });
            }
        }

        public T PostType<T>(string route, object data = null)
        {
            return ClientService<T>().PostType(route: route, data: data, userId: GurselFrameworkSession.UserId, computerName: ComputerName);
        }

        public T GetType<T>(string route, object data = null, int userId = -1)
        {
            return ClientService<T>().GetType(route: route, data: data, userId: GurselFrameworkSession.UserId, computerName: ComputerName);
        }
        protected string FileType(string route, string file)
        {
            return ClientService<string>().FileType(route: route, file: file);
        }
        public void RunScript(string content)
        {
            if (Request.IsAjaxRequest())
            {
                Response.Write(GetScript(content));
            }
            else
            {
                ViewBag.Script += GetScript(content);
            }
        }

        public string GetScript(string content)
        {
            return $"<script>{content}</script>";
        }
    }
}