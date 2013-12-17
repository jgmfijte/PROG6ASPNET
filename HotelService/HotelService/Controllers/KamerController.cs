using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HotelService.Controllers
{
    public class KamerController : Controller
    {
        //
        // GET: /Kamer/

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult KamerOverzicht()
        {
            return View();
        }

        public ActionResult KamerNieuw()
        {
            return View();
        }
    }
}
