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
            List<object> kamerList = new List<object>();
            List<object> klantList = new List<object>();

            foreach (var kamer in context.Hotelkamers)
            {
                kamerList.Add(kamer.KamerNummer);
            }

            foreach (var klant in context.Klantens)
            {
                klantList.Add(klant.KlantNummer);
            }
            
            ViewData["KamerList"] = kamerList;
            ViewData["KlantList"] = klantList;
     
            return View();
        }

        [MedewerkersFilter]
        [HttpPost]
        public ActionResult Created(DataAccessLayer.Boekingen boeking)
        {
            if (ModelState.IsValid)
            {
                boeking.Status = "In Behandeling";

                context.Boekingens.InsertOnSubmit(boeking);                
                context.SubmitChanges();
                return View();
            }
            //invoeren in db
            return View("Create", boeking);
        }

        [MedewerkersFilter]
        public ActionResult Edit()
        {
            return View();
        }
        [MedewerkersFilter]
        public ActionResult Delete(int boekingsNr)
        {
            var queryResult = from s in context.Boekingens
                              where s.BoekingsNr == boekingsNr
                              select s;
            return View(queryResult.FirstOrDefault());
        }
        public ActionResult Deleted(int boekingsNr)
        {
            var deleteBoekingen = from boeking in context.Boekingens
                                     where boeking.BoekingsNr == boekingsNr
                                     select boeking;

            foreach (var boeking in deleteBoekingen)
            {
                context.Boekingens.DeleteOnSubmit(boeking);
            }

            try
            {
                context.SubmitChanges();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                // Provide for exceptions.
            }
            return View();
        }
    }
}
