using Mvc3Examples.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Security.Principal;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using System.Web.Script.Serialization;
using System.Web.Security;

namespace Mvc3Examples
{
    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801

    public class MvcApplication : System.Web.HttpApplication
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }

        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            routes.MapRoute(
                "HelpersRoute",
                "Helpers/{action}",
                new { controller = "Helpers", action = "Index" }
            );
            routes.MapRoute(
                "AttributesRoute",
                "Attributes/{action}",
                new { controller = "Attributes", action = "Index" }
            );
            routes.MapRoute(
                "SecurityRoute",
                "Security/{action}",
                new { controller = "Security", action = "Index" }
            );
            routes.MapRoute(
                "AjaxRoute",
                "Ajax/{action}",
                new { controller = "Ajax", action = "Index" }
            );
            routes.MapRoute(
                "ValidateSchool",
                "Attributes/{action}",
                new { controller = "Attributes", action = "ValidateSchool" }
            );
            routes.MapRoute(
                "Default", // Route name
                "{controller}/{action}/{id}", // URL with parameters
                new { controller = "Home", action = "Index", id = UrlParameter.Optional } // Parameter defaults
            );

        }

        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();

            RegisterGlobalFilters(GlobalFilters.Filters);
            RegisterRoutes(RouteTable.Routes);
        }

        protected void Application_PostAuthenticateRequest(Object sender, EventArgs e) {
            //get the cookie here
            HttpCookie authCookie = 
                Context.Request.Cookies[FormsAuthentication.FormsCookieName];
            if (authCookie != null  ) {
                FormsAuthenticationTicket authTicket = 
                                  FormsAuthentication.Decrypt(authCookie.Value);
                string roles = "";
                if(authTicket.UserData != null){
                    AccountModel model = new JavaScriptSerializer().Deserialize<AccountModel>(authTicket.UserData);
                    if(model != null && !String.IsNullOrEmpty(model.Role))
                        roles = model.Role;
                }
                //user that represents the authenticated request
                GenericPrincipal userPrincipal =
                       new GenericPrincipal(new GenericIdentity(authTicket.Name), roles.Split(','));
                Context.User = userPrincipal;
            }
        }
    }
}