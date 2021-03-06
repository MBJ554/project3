﻿using System;
using System.Web.Mvc;

namespace Web.Controllers
{
    public class HomeController : Controller
    {
        /// <summary>
        /// Main Home Page
        /// </summary>
        /// <returns>HomePage View</returns>
        public ActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// Main booking entry page.
        /// </summary>
        /// <returns>Book View</returns>
        public ActionResult Book()
        {
            ViewBag.Message = "Your application description page.";
            ViewBag.CurrentDate = DateTime.Now.ToString("yyyy-MM-dd");

            return View();
        }
    }
}