using DataAccessLayer;
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

        DatabaseClassesDataContext context = new DatabaseClassesDataContext();

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult KamerOverzicht()
        {
            var result =
                from k in context.Hotelkamers
                select k;
            return View(result);
        
        }

        public ActionResult Create()
        {
            return View();
        }

        public ActionResult Delete()
        {
            return View();
        }

        public ActionResult Edit()
        {
            return View();
        }
    }
}
