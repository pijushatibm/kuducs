using dollybal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace dolly.Controllers
{
    public class HomeController : Controller
    {
        DollyElementContext db = new DollyElementContext();
        public ActionResult Index()
        {
            var sheeps = db.Sheeps.ToList();
            ViewBag.List = sheeps;
            return View(sheeps);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}