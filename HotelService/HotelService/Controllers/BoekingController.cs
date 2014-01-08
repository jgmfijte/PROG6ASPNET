using DataAccessLayer;
using HotelService.Filters;
using HotelService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HotelService.Controllers
{
    [LoggedInFilter]
    public class BoekingController : Controller
    {
        //
        // GET: /Boeking/

        DatabaseClassesDataContext context = SingletonDatabase.Instance;

        public ActionResult Index()
        {
            return View();
        }

        [MedewerkersFilter]
        public ActionResult BoekingOverzicht()
        {
            var result =
                from b in context.Boekingens
                select b;
            return View(result);
        }

        [KlantFilter]
        public ActionResult KlantBoekingOverzicht()
        {
            HttpCookie userCookie = HttpContext.Request.Cookies["LoginCookie"];
            string userID = userCookie.Values["userID"];
            int user = Convert.ToInt32(userID);
            var result =
                from b in context.Boekingens
                where b.Boeking_KlantNr == user
                select b;
            
            return View(result);
        }

        public ActionResult Create()
        {
            return View();
        }

        public ActionResult Edit()
        {
            return View();
        }
        public ActionResult Delete()
        {
            return View();
        }
    }
}
