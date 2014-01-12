using DataAccessLayer;
using HotelService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HotelService.Controllers
{
    public class KlantController : Controller
    {
        DatabaseClassesDataContext context = SingletonDatabase.Instance;

        //
        // GET: /Gebruiker/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Gebruiker/Create

        [HttpPost]
        public ActionResult Created(DataAccessLayer.Klanten klant)
        {
            DataAccessLayer.Gebruiker gebruiker = new Gebruiker();
            int maxID = context.Gebruikers.Max(u => u.userID);

            gebruiker.Voornaam = klant.Voornaam;
            gebruiker.Achternaam = klant.Achternaam;
            gebruiker.tussenvoegsel = klant.tussenvoegsel;
            gebruiker.rol = "Klant";
            gebruiker.userID = maxID + 1;
            gebruiker.wachtwoord = klant.password;
            klant.userID = maxID + 1;

            context.Gebruikers.InsertOnSubmit(gebruiker);
            context.SubmitChanges();
            context.Klantens.InsertOnSubmit(klant);
            context.SubmitChanges();
            return View();
        }       
    }
}
