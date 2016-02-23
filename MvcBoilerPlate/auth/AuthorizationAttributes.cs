using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Routing;
using System.Web.Mvc;
using MvcBoilerPlate.Controllers;

namespace MvcBoilerPlate.auth
{
    public class RoleTypeActionAttribute : Attribute
    {
        private string _type;

        public RoleTypeActionAttribute(string type)
        {
            _type = type;
        }

        public string GetRoleType()
        {
            return _type;
        }
    }

    public class AuthenticateRoleAttribute : AuthorizeAttribute
    {
        public override void OnAuthorization(AuthorizationContext filterContext)
        {
            bool hasAccess;

            hasAccess = true; // Replace this with SQL query to find out if the user is authenticated with the system

            if (!hasAccess)
            {
                filterContext.Result = new RedirectToRouteResult(new RouteValueDictionary {
                    { "action", "NotAuthorized" },
                    { "controller", "Home" }
                });
            }
        }
    }

    public class AuthorizeRoleAttribute : AuthorizeAttribute
    {
        public AuthorizeRoleAttribute()
            : base()
        {
        }

        public override void OnAuthorization(AuthorizationContext filterContext)
        {
            bool hasAccess = false;

            // If a role type is required, check if user's role type action is allowed
            if (filterContext.ActionDescriptor.GetCustomAttributes(typeof(RoleTypeActionAttribute), true).Length > 0)
            {
                // get the role for this action
                string roleType = ((RoleTypeActionAttribute)filterContext.ActionDescriptor.GetCustomAttributes(typeof(RoleTypeActionAttribute), true)[0]).GetRoleType();

                
                if (filterContext.Controller.ValueProvider.GetValue("role") != null)
                {
                    foreach (string s in roleType.Split(new string[] { "," }, StringSplitOptions.None))
                    {
                        hasAccess = s ==
                            // -- Replace this with a SQL query to find out if the user is authorized with the specified role type (e.g. Admin) --
                            filterContext.Controller.ValueProvider.GetValue("role").AttemptedValue;
                            // ----
                        if (hasAccess) { break; }
                    }
                }

                if (!hasAccess)
                {
                    filterContext.Result = new RedirectToRouteResult(new RouteValueDictionary {
                    { "action", "NotAuthorized" },
                    { "controller", "Home" }
                });
                }
            }
        }
    }
}