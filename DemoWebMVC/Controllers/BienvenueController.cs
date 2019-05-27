using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DemoWebMVC.Controllers
{
    public class BienvenueController : Controller
    {
        // GET: Bienvenue
        [Route("Bienvenue/Invite")]
        public ActionResult Invite()
        {
            return View();
        }
    }
}