using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ClientWeb
{
    public class UserAuthentication : ActionFilterAttribute, IAuthorizationFilter
    {
        public void OnAuthorization(AuthorizationContext filterContext)
        {
            if (HttpContext.Current.Session["User"] == null)
            {
                HttpContext.Current.Session["Error"] = "bu sayfaya girmek için önce login olmaslısınız";
                filterContext.Result = new RedirectResult("/Login/Login");
            }
        }
    }
}