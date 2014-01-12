using DataAccessLayer;
using HotelService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HotelService.Controllers
{
    public class GebruikerController : Controller
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
        public ActionResult Created(DataAccessLayer.Gebruiker gebruiker)
        {
            gebruiker.rol = "Klant";
            int maxUsernr = context.Gebruikers.Max(u => u.userID);
            gebruiker.userID = maxUsernr + 1;
            context.Gebruikers.InsertOnSubmit(gebruiker);
            context.SubmitChanges();
            return View();
        }       
    }
}
