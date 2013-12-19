using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HotelService.Controllers
{
    public class GastController : Controller
    {
        //
        // GET: /Gast/

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult GastOverzicht()
        {
            return View();
        }

        public ActionResult GastNieuw()
        {
            return View();
        }

        public ActionResult Details()
        {
            return View();
        }
    }
}
