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
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }

        public async Task<ActionResult> UserLogin(string email, string password)
        {
            LoginCaller lc = new LoginCaller();
            var customer = await lc.GetByLogin(email, password);
            if (customer != null)
            {
                PractitionerCaller pc = new PractitionerCaller();
                Session["UserId"] = customer.Id.ToString();
                Practitioner p = await pc.GetPractitionerId(customer.Practitioner);
                Session["PractitionerId"] = p.Id.ToString();
            }
            else
            {
                ViewBag.ErrorMessage = "Brugeren findes ikke, brugernavn eller password passer ikke";
                return View("Index");
            }
            return RedirectToAction("Index", "Home");
        }

        public ActionResult UserNotFound() {
            return View();
        }
    }
}