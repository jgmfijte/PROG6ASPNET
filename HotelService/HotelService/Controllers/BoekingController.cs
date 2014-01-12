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

        [MedewerkersFilter]
        public ActionResult Edit(int boekingsNr)
        {
            var queryResult = from k in context.Boekingens
                              where k.BoekingsNr == boekingsNr
                              select k;
            return View(queryResult.FirstOrDefault());
        }
        [MedewerkersFilter]
        public ActionResult Edited(int BoekingsNr, int Boeking_KamerNr, DateTime Startdatum, DateTime Einddatum, int Boeking_KlantNr)
        {
            var query = from boeking in context.Boekingens
                        where boeking.BoekingsNr == BoekingsNr
                        select boeking;
            foreach (var boeking in query)
            {
                boeking.BoekingsNr = BoekingsNr;
                boeking.Boeking_KamerNr = Boeking_KamerNr;
                boeking.Startdatum = Startdatum;
                boeking.Einddatum = Einddatum;
                boeking.Boeking_KlantNr = Boeking_KlantNr;
            }
            context.SubmitChanges();

            var allBookings = from booking in context.Boekingens
                            select booking;
            return View("BoekingOverzicht", allBookings);
        }
    }
}
