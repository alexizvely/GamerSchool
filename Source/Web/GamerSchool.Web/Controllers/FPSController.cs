using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GamerSchool.Web.Controllers
{
    public class FPSController : Controller
    {
        // GET: FPS
        public ActionResult Index()
        {
            return View();
        }
    }
}