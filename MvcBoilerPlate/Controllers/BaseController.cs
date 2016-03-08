using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Web;
using System.Web.Mvc;
using MvcBoilerPlate.util;

namespace MvcBoilerPlate.Controllers
{
    public class BaseController : Controller
    {
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

        //
        // GET: /Home/NotAuthorized
        public ActionResult NotAuthorized()
        {
            return View("~/Views/Shared/NoAuth.cshtml");
        }

    }
}
