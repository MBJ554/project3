using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Security.Principal;
using System.Web.Mvc;
using Web.Callers;


namespace Web.CustomAuthorize
{
    /// <summary>
    /// Method-Attribute / Decorator checks user permissions and redirects if necessary for authorization.
    /// </summary>
    public class LoginRequired : AuthorizeAttribute
    {
        /// <summary>
        /// Checks if a users is authorized.
        /// </summary>
        /// <param name="httpContext"></param>
        /// <returns>Boolean result</returns>
        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            return HttpContext.Current.Session["UserId"] != null;
        }

        /// <summary>
        /// Takes action if user/session is not authorized
        /// </summary>
        /// <param name="filterContext"></param>
        protected override void HandleUnauthorizedRequest(AuthorizationContext filterContext)
        {
            filterContext.Result = new RedirectResult("Login");
        }
    }
}