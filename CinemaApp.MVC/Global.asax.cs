using BLL;
using IBL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace CinemaApp.MVC
{
    public class MvcApplication : System.Web.HttpApplication
    {
        private IRoleAuthenticationService roleAuthenticationService;
      

        public MvcApplication()
        {
            this.roleAuthenticationService = new RoleAuthenticationService();
                
        }

        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }
        protected void Application_AuthenticateRequest()
        {
            if (User == null)
            {
                return;
            }
            string emailAddress = Context.User.Identity.Name;
            int userId = roleAuthenticationService.GetUserIdByIdentityName(emailAddress);
            string[] roles = roleAuthenticationService.GetUserRolesById(userId);
            IIdentity identity = new GenericIdentity(emailAddress);
            IPrincipal principal = new GenericPrincipal(identity, roles);
            Context.User = principal;
           
        }
    }
}
