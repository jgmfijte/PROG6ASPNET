﻿using DataAccessLayer;
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
        public ActionResult Details()
        {
            return View();
        }

        [MedewerkersFilter]
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
