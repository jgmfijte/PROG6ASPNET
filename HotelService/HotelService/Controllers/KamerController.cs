using DataAccessLayer;
using HotelService.Filters;
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
        [KlantFilter]
        public ActionResult KlantKamerOverzicht()
        {
            var result =
                from k in context.Hotelkamers
                select k;
            return View(result);
        }
        [MedewerkersFilter]
        public ActionResult KamerOverzicht()
        {
            var result =
                from k in context.Hotelkamers
                select k;
            return View(result);
        
        }

        [MedewerkersFilter]
        [HttpPost]
        public ActionResult Created(DataAccessLayer.Hotelkamer kamer)
        {
            if (ModelState.IsValid)
            {

                context.Hotelkamers.InsertOnSubmit(kamer);
                context.SubmitChanges();
                return View();
            }
            //invoeren in db
            return View("Create", kamer);
        }

        [MedewerkersFilter]
        public ActionResult Create()
        {
            return View();
        }

        [MedewerkersFilter]
        public ActionResult Delete(int kamerNr)
        {
            var queryResult = from s in context.Hotelkamers
                              where s.KamerNummer == kamerNr
                              select s;
            return View(queryResult.FirstOrDefault());
        }
        public ActionResult Deleted(int kamerNr)
        {
            var deleteKamers = from kamer in context.Hotelkamers
                                  where kamer.KamerNummer == kamerNr
                                  select kamer;

            foreach (var kamer in deleteKamers)
            {
                context.Hotelkamers.DeleteOnSubmit(kamer);
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
        public ActionResult Edit()
        {
            return View();
        }
    }
}
