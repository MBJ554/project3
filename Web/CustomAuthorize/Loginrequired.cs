using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Security.Principal;
using System.Web.Mvc;
using Web.Callers;


namespace Web.CustomAuthorize
{
    public class MyAuthorize : AuthorizeAttribute
    {

        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
           
            bool authorize = false;
            HttpContext hc = HttpContext.Current;
            var user = hc.Session["UserId"];
            if (user != null) {
               
                authorize = true;
            }

            return authorize;
        }

        protected override void HandleUnauthorizedRequest(AuthorizationContext filterContext)
        {
            if (!filterContext.HttpContext.User.Identity.IsAuthenticated)
            {
                filterContext.Result = new ViewResult() { ViewName = "UnAuthorize" };
            }
            else {
                filterContext.Result = new HttpUnauthorizedResult();
            }
                
        }


    }
}