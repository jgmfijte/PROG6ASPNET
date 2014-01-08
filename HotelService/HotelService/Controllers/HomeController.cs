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
    public class HomeController : Controller
    {
        //
        // GET: /Home/

        DatabaseClassesDataContext context = SingletonDatabase.Instance;

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Login(int userID, string wachtwoord)
        {
            IQueryable<DataAccessLayer.Gebruiker> userResult = from u in context.Gebruikers
                             where u.userID == userID && u.wachtwoord == wachtwoord
                             select u;
            if (userResult != null)
            {
                DataAccessLayer.Gebruiker found = userResult.FirstOrDefault();
                HttpCookie login = new HttpCookie("LoginCookie");
                login.Values.Add("voornaam", found.Voornaam);
                login.Values.Add("tussenvoegsel", found.tussenvoegsel);
                login.Values.Add("achternaam", found.Achternaam);
                login.Values.Add("rol", found.rol);
                login.Values.Add("userID", found.userID.ToString());
                login.Expires = DateTime.Now.AddHours(4);
                Response.Cookies.Add(login);

                if (found.rol == "Klant")
                {
                    return View("KlantIndex");
                }
                else if (found.rol == "Medewerker")
                {
                    return View("MedewerkersIndex");
                }
            }
            return View("Index");
        }

        public ActionResult Logoff() 
        {
            if (Request.Cookies["LoginCookie"] != null)
            {
                HttpCookie myCookie = new HttpCookie("LoginCookie");
                myCookie.Expires = DateTime.Now.AddDays(-1d);
                Response.Cookies.Add(myCookie);
            }
            return View("Index");
        }

        [LoggedInFilter]
        public ActionResult KlantIndex()
        {
            HttpCookie userCookie = HttpContext.Request.Cookies["LoginCookie"];
            string userID = userCookie.Values["userID"];
            int user = Convert.ToInt32(userID);
            IQueryable<DataAccessLayer.Gebruiker> userResult = from u in context.Gebruikers
                                                               where u.userID == user
                                                               select u;
            if (userResult != null)
            {
                DataAccessLayer.Gebruiker foundUser = userResult.FirstOrDefault();
                return View(foundUser);
            }
            else
            {
                return View("Index");
            }
        }

        [LoggedInFilter]
        [MedewerkersFilter]
        public ActionResult MedewerkersIndex()
        {
            return View();
        }

        public ActionResult KlantNotAllowed()
        {
            return View();
        }

        public ActionResult MedewerkerNotAllowed()
        {
            return View();
        }
    }
}
