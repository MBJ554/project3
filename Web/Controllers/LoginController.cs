using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Web.Callers;
using Web.Models;

namespace Web.Controllers
{
    public class LoginController : Controller
    {
        /// <summary>
        /// Main Login Page.
        /// </summary>
        /// <returns>Login View</returns>
        public ActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// User login page. Validates user.
        /// </summary>
        /// <param name="email">The email given by the user</param>
        /// <param name="password">The password given by the user</param>
        /// <returns>Returns to Main/home page if user is valid, else returns login view with error message</returns>
        public async Task<ActionResult> UserLogin(string email, string password)
        {
            LoginCaller lc = new LoginCaller();
            var customer = await lc.GetByLogin(email, password);
            if (customer != null)
            {
                PractitionerCaller pc = new PractitionerCaller();
                Session["UserId"] = customer.Id.ToString();
                Practitioner p = await pc.GetPractitionerByURL(customer.Practitioner);
                Session["PractitionerId"] = p.Id.ToString();
            }
            else
            {
                ViewBag.ErrorMessage = "Brugeren findes ikke, brugernavn eller password passer ikke";
                return View("Index");
            }
            ViewBag.SuccessMessage = "Du er nu logget ind, velkommen til " + customer.FirstName + "!";
            return View("Index", "Home");
        }
        /// <summary>
        /// Logout a user by clearing and deleting the current autheticated session.
        /// </summary>
        /// <returns>Home view with loged out successmessage</returns>
        public async Task<ActionResult> Logout()
        {
            Session.Clear();
            Session.Abandon();
            ViewBag.SuccessMessage = "Håber vi ses snart igen!";
            return View("Index", "Home");
        }
    }
}