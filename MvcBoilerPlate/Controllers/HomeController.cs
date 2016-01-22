using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcBoilerPlate.auth;

namespace MvcBoilerPlate.Controllers
{
    [AuthenticateRole]
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
        [AuthorizeRole]
        public ActionResult Restricted()
        {
            return View();
        }

    }
}
