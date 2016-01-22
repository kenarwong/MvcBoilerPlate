﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using MvcBoilerPlate.util;

namespace MvcBoilerPlate.Controllers
{
    public class BaseController : Controller
    {
        //
        // GET: /Base/

        public ActionResult NoAuth()
        {
            return View("~/Views/Shared/NoAuth.cshtml");
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

    }
}