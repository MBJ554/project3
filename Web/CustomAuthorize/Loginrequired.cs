using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Security.Principal;
using System.Web.Mvc;
using Web.Callers;


namespace Web.CustomAuthorize
{
    public class LoginRequired : AuthorizeAttribute
    {

        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            bool authorize = false;
            if (HttpContext.Current.Session["UserId"] != null) {
                authorize = true;
            }

            return authorize;
        }

        protected override void HandleUnauthorizedRequest(AuthorizationContext filterContext)
        {
            filterContext.Result = new RedirectToRouteResult(
                new System.Web.Routing.RouteValueDictionary { {"Controller", "Login" }, {"View", "Index" } }) ;
        }


    }
}