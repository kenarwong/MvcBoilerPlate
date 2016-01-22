using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcBoilerPlate.auth;

namespace MvcBoilerPlate.Controllers
{
    [AuthenticateRole]
    [AuthorizeRole]
    public class HomeController : BaseController
    {
        //
        // GET: /Home/
        public ActionResult Index()
        {
            return View();
        }

        //
        // GET: /Home/Restricted
        [RoleTypeAction("Admin")]
        public ActionResult Restricted(string role)
        {
            return View();
        }

        //
        // GET: /Home/NotAuthorized
        public ActionResult NotAuthorized()
        {
            return View("~/Views/Shared/NoAuth.cshtml");
        }

    }
}
