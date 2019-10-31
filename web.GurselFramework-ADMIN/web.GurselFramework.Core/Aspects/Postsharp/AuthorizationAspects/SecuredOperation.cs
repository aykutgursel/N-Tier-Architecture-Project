using PostSharp.Aspects;
using System;
using System.Linq;
using System.Threading;
using System.Web;

namespace web.GurselFramework.Core.Aspects.Postsharp.AuthorizationAspects
{
    [Serializable]
    public class SecuredOperation : OnMethodBoundaryAspect
    {
        public string Roles { get; set; }

        public override void OnEntry(MethodExecutionArgs args)
        {
            string[] roles = Roles.Split(',');
            bool isAuthorize = false;

            for (int i = 0; i < roles.Length; i++)
            {
                try
                {
                    if (Thread.CurrentPrincipal.IsInRole(roles[i]))
                    {
                        if (HttpContext.Current.Request.Cookies.AllKeys.Contains("IsAdmin"))
                        {
                            if (HttpContext.Current.Request.Cookies["IsAdmin"].Value == "True")
                            {
                                isAuthorize = true;
                            }
                        }
                    }
                    else
                    {
                        isAuthorize = false;
                    }
                }
                catch
                {

                    isAuthorize = false;
                }

            }

            if (!isAuthorize)
            {
                HttpContext.Current.Response.Redirect("/Anasayfa");

            }
        }
    }
}
