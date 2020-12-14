using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
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

        /// <summary>
        /// Main entry page for contact page
        /// </summary>
        /// <returns>Main Contact View</returns>
        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}