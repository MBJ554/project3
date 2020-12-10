using API.DAL.Exceptions;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Web.Callers;
using Web.CustomAuthorize;
using Web.Models;

namespace Web.Controllers
{
    [LoginRequired]
    public class BookAppointmentController : Controller
    {
       
        // GET: BookAppointment
        public ActionResult Index()
        {       
            return View();           
        }

        public async Task<ActionResult> ChooseAppointmentTime(DateTime date)
        {
            // TODO Validate the date so the server wont accept dates out of range but instead redirect to 'Index,View' with a ViewBag.ErrorMessage = "Date not valid"
            DateTime currentDate = new DateTime();
            if (date < currentDate || date.DayOfWeek == DayOfWeek.Saturday || date.DayOfWeek == DayOfWeek.Sunday)
            {
                ViewBag.ErrorMessage = "Det ville være pænt nice hvis du valgte en valid dag";
                return View();
            }
            AppointmentCaller appointmentCaller = new AppointmentCaller();
            var appointments = await appointmentCaller.GetByDate(date, Session["PractitionerId"] as string);
            return View(appointments);
        }


        [HandleError(ExceptionType = typeof(Exception), View = "BookErrorView")]
        public ActionResult BookTime(DateTime startDate, DateTime endDate) {
            Appointment a = new Appointment();
            a.Enddate = endDate;
            a.Startdate = startDate;
            // TODO tilføj kunde og udøver // No dansker snak in da code ;)
           
            a.Customer = Session["UserId"] as string;
            a.Practitioner = Session["PractitionerId"] as string;
            AppointmentCaller ac = new AppointmentCaller();
            ac.BookTime(a);
            return View(a); ;
        }
        

    }
}