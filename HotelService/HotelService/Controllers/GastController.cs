using DataAccessLayer;
using HotelService.Models;
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
        DatabaseClassesDataContext context = SingletonDatabase.Instance;

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult GastOverzicht()
        {
            var result =
                from k in context.Klantens
                select k;
            return View(result);
        }

        public ActionResult Create()
        {
            return View();
        }

        public ActionResult Details()
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
