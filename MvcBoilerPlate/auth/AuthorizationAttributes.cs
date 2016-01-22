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

            hasAccess = true;

            if (!hasAccess)
            {
                filterContext.Result = new RedirectToRouteResult(new RouteValueDictionary {
                    { "action", "NoAuth" },
                    { "controller", "Base" }
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
            bool hasAccess;

            hasAccess = false;

            if (!hasAccess)
            {
                filterContext.Result = new RedirectToRouteResult(new RouteValueDictionary {
                    { "action", "NoAuth" },
                    { "controller", "Base" }
                });
            }

            //usrCtx = new UserContext(HttpContext.Current);
            //List<UserRole> usrRoles = usrCtx.GetUserActions().ToList();

            //// Check role access
            //hasAccess = usrRoles.Where(
            //        item => item.CONTROLLER == filterContext.ActionDescriptor.ControllerDescriptor.ControllerName).Count() > 0;

            //if (filterContext.ActionDescriptor.GetCustomAttributes(typeof(RoleTypeActionAttribute), true).Length > 0)
            //{
            //    // If a role type is required, check if user's role type action is allowed
            //    string roleType = ((RoleTypeActionAttribute)filterContext.ActionDescriptor.GetCustomAttributes(typeof(RoleTypeActionAttribute), true)[0]).GetRoleType();

            //    hasAccess = usrRoles.Where(
            //        item => item.CONTROLLER == filterContext.ActionDescriptor.ControllerDescriptor.ControllerName
            //        && item.ROLE_TYPE_DESCRIPTION == roleType).Count() > 0;
            //}
            
            //if (!hasAccess)
            //{
            //    filterContext.Result = new RedirectToRouteResult(new System.Web.Routing.RouteValueDictionary {
            //        { "action", "NoAuth" },
            //        { "controller", "Role" }
            //    });
            //}
            //base.OnAuthorization(filterContext);
        }
    }
}