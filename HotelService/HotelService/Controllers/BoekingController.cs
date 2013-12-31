using DataAccessLayer;
using HotelService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HotelService.Controllers
{
    public class BoekingController : Controller
    {
        //
        // GET: /Boeking/

        DatabaseClassesDataContext context = SingletonDatabase.Instance;

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult BoekingOverzicht()
        {
            var result =
                from b in context.Boekingens
                select b;
            return View(result);
        }

        public ActionResult KamerNieuw()
        {
            return View();
        }
    }
}
