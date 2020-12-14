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
        public ActionResult Index()
        {       
            return View();           
        }

        /// <summary>
        /// Uses date to fetch all appointment-times for that date/practitioner using the API/AppointmentCaller.
        /// Also there is a client side validation of the date selected.
        /// </summary>
        /// <param name="date">Find all appointment times on this date</param>
        /// <returns></returns>
        public async Task<ActionResult> ChooseAppointmentTime(DateTime date)
        {
            DateTime currentDate = new DateTime();
            if (date < currentDate || date.DayOfWeek == DayOfWeek.Saturday || date.DayOfWeek == DayOfWeek.Sunday)
            {
                ViewBag.ErrorMessage = "Du skal vælge en date der er valid og vi holder ikke åben i weekenden!";
                return View();
            }
            AppointmentCaller appointmentCaller = new AppointmentCaller();
            var appointments = await appointmentCaller.GetByDate(date, Session["PractitionerId"] as string);
            return View(appointments);
        }

        /// <summary>
        /// BookTime takes the two datetime objects and uses the API to book a time for the selected date, practitioner and time span selected.
        /// Concurrency issues throws exception with suitable response message. The 'ChoseAppointmentTime'-view is shown with the error message.
        /// </summary>
        /// <param name="startDateTime">aka apointment start time</param>
        /// <param name="endDateTime">aka apointment end time</param>
        /// <returns>The new appoinment is passed to the view if successfull</returns>
        public ActionResult BookTime(DateTime startDateTime, DateTime endDateTime) {
            Appointment a = new Appointment();
            a.Enddate = endDateTime;
            a.Startdate = startDateTime;
           
            a.Customer = Session["UserId"] as string;
            a.Practitioner = Session["PractitionerId"] as string;
            AppointmentCaller ac = new AppointmentCaller();
            try
            {
                ac.BookTime(a);
            }
            catch (Exception e)
            {
                ViewBag.ErrorMessage = "[ERROR] " + e.Message;
                return View(ChooseAppointmentTime(endDateTime.Date));
            }
   
            return View(a); ;
        }
    }
}