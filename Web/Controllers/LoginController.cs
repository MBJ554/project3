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

        public async Task<ActionResult> UserLogin(string userName, string password) {

            LoginCaller lc = new LoginCaller();
            bool res = await lc.GetByLogin(userName, password);
            if (res)
            {
                Session["UserID"] = userName;
                Session["UserName"] = password;
            }
            else
            {
                ViewBag.ErrorMessage = "Brugeren findes ikke, brugernavn eller password passer ikke";
                return View();
            }
            return RedirectToAction("Index", "Home");
        }


        public ActionResult UserNotFound() {
            return View();
        }
    }
}