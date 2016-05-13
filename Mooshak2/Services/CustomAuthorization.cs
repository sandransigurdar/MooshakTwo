using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Mooshak2.Services
{
    public class CustomAuthorization: AuthorizeAttribute
    {
        
        public override void OnAuthorization(AuthorizationContext filterContext)
        {
            int loggedInStudentRole = LoginService.userRole;

            if (loggedInStudentRole != userRole)
            {
                filterContext.Result = new RedirectToRouteResult(new System.Web.Routing.RouteValueDictionary(new { controller = "Home", action = "PermissionDenied" }));
            }
        }

        int userRole;
        public CustomAuthorization(int userRole):base()
        {
            this.userRole = userRole; 
        }
    }
}