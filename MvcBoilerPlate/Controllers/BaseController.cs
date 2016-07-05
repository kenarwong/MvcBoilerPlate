using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Web;
using System.Web.Mvc;
using MvcBoilerPlate.util;
using MvcBoilerPlate.Models;

namespace MvcBoilerPlate.Controllers
{
    public class BaseController : Controller
    {
        #region Protected Properties
        protected string UserName { get; private set; }
        protected int UserID { get; private set; }
        protected Role UserRole { get; private set; }
        #endregion

        #region Helper Classes
        public class AjaxRequestAttribute : ActionMethodSelectorAttribute
        {
            public override bool IsValidForRequest(ControllerContext controllerContext, MethodInfo methodInfo)
            {
                return controllerContext.HttpContext.Request.IsAjaxRequest();
            }
        }

        protected override JsonResult Json(object data, string contentType, Encoding contentEncoding, JsonRequestBehavior behavior)
        {
            return new JsonNetResult
            {
                Data = data,
                ContentType = contentType,
                ContentEncoding = contentEncoding,
                JsonRequestBehavior = behavior
            };
        }
        #endregion

        #region Shared Route
        //
        // GET: /NotAuthorized
        public ActionResult NotAuthorized()
        {
            return View("~/Views/Shared/NoAuth.cshtml");
        }
        #endregion

        #region Events
        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            base.OnActionExecuting(filterContext);
        }
        #endregion
    }
}
