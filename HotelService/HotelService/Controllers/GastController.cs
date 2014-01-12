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
    public class GastController : Controller
    {
        //
        // GET: /Gast/
        DatabaseClassesDataContext context = SingletonDatabase.Instance;

        public ActionResult Index()
        {
            return View();
        }

        [MedewerkersFilter]
        public ActionResult GastOverzicht()
        {
            var result =
                from k in context.Klantens
                select k;
            return View(result);
        }

        [MedewerkersFilter]
        public ActionResult Create()
        {
            return View();
        }

        [MedewerkersFilter]
        [HttpPost]
        public ActionResult Created(DataAccessLayer.Klanten gast)
        {
            if (ModelState.IsValid)
            {
                
                context.Klantens.InsertOnSubmit(gast);
                context.SubmitChanges();
                return View();
            }
            //invoeren in db
            return View("Create", gast);
        }

        [MedewerkersFilter]
        public ActionResult Details(int klantNr)
        {
            var queryResult = from s in context.Klantens
                              where s.KlantNummer == klantNr
                              select s;
            return View(queryResult.FirstOrDefault());
        }

        [MedewerkersFilter]
        public ActionResult Delete(int klantNr)
        {
            var queryResult = from s in context.Klantens
                              where s.KlantNummer == klantNr
                              select s;
            return View(queryResult.FirstOrDefault());
        }
        [MedewerkersFilter]
        public ActionResult Deleted(int klantNr)
        {
            var deleteBoekingen = from boeking in context.Boekingens
                                  where boeking.Boeking_KlantNr == klantNr
                                  select boeking;
            var deleteKlant = from klant in context.Klantens
                              where klant.KlantNummer == klantNr
                              select klant;
            foreach (var boeking in deleteBoekingen)
            {
                context.Boekingens.DeleteOnSubmit(boeking);
            }
            foreach (var klant in deleteKlant)
            {
                context.Klantens.DeleteOnSubmit(klant);
            }
            
            context.SubmitChanges();
            
            return View();
        }
        [MedewerkersFilter]
        public ActionResult Edit(int klantNr)
        {
            var queryResult = from k in context.Klantens
                              where k.KlantNummer == klantNr
                              select k;
            return View(queryResult.FirstOrDefault());
        }
        [MedewerkersFilter]
        public ActionResult Edited(int KlantNummer, string Voornaam, string tussenvoegsel, string Achternaam, string Geslacht, string Adres, string Postcode, string Woonplaats, string Email)
        {
            var query = from klant in context.Klantens
                        where klant.KlantNummer == KlantNummer
                        select klant;
            foreach (var klant in query)
            {
                klant.KlantNummer = KlantNummer;
                klant.Voornaam = Voornaam;
                klant.tussenvoegsel = tussenvoegsel;
                klant.Achternaam = Achternaam;
                klant.Geslacht = Geslacht;
                klant.Adres = Adres;
                klant.Postcode = Postcode;
                klant.Woonplaats = Woonplaats;
                klant.Email = Email;
            }
            context.SubmitChanges();

            var allGuests = from guest in context.Klantens
                           select guest;
            return View("GastOverzicht", allGuests);
        }
    }
}
