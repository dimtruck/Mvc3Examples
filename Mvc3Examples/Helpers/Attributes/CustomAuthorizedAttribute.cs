using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Web;
using System.Web.Mvc;

namespace Mvc3Examples.Helpers.Attributes
{
    public class CustomAuthorizedAttribute : AuthorizeAttribute
    {
        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            //check some stuff on httpcontext
            IPrincipal user = httpContext.User;
            if (user.IsInRole("my-custom-role"))
                return true;
            return false;
        }
    }
}