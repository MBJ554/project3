using API.DAL.Exceptions;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Web.Callers;
using Web.Models;

namespace Web.Controllers
{
    public class BookAppointmentController : Controller
    {
        // GET: BookAppointment
        public ActionResult Index()
        {
            var ID = Session["UserId"];
            if (ID != null)
            {
                return View();
            }
            return RedirectToAction("Index", "Login");
        }

        public async Task<ActionResult> ChooseAppointmentTime(DateTime date)
        {
            // TODO Validate the date so the server wont accept dates out of range but instead redirect to 'Index,View' with a ViewBag.ErrorMessage = "Date not valid"
            AppointmentCaller appointmentCaller = new AppointmentCaller();
            var bookedAppointments = await appointmentCaller.GetByDate(date, Session["PractitionerId"] as string);

            // List<Appointment> bookedAppointments = new List<Appointment>();
            // Appointment bookedAppointment = new Appointment();
            // bookedAppointment.Startdate = DateTime.Today.AddHours(10);
           
            List<Appointment> allowedAppointments = new List<Appointment>();
            for (int i = 0; i < 14; i++)
            {
                Appointment a = new Appointment();
                a.Startdate = date.AddHours(8 + (i * 0.50));
                a.Enddate = date.AddHours(8 + (i * 0.5 + 0.5));
                allowedAppointments.Add(a);
            }
            List<Appointment> checkList = new List<Appointment>(allowedAppointments);
            if (bookedAppointments != null) {
                foreach (Appointment a in bookedAppointments)
                {
                    foreach (Appointment ap in checkList) 
                    {
                        if (a.Startdate == ap.Startdate) 
                        {
                            allowedAppointments.Remove(ap);
                        }
                    }
                }
            }
            return View(allowedAppointments);
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