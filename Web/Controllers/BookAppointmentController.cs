﻿using System;
using System.Threading.Tasks;
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
        public ActionResult ChooseAppointmentTime(DateTime date)
        {
            DateTime currentDate = new DateTime();
            if (date < currentDate || date.DayOfWeek == DayOfWeek.Saturday || date.DayOfWeek == DayOfWeek.Sunday)
            {
                TempData["ErrorMessage"] = "Du skal vælge en date der er valid og vi holder ikke åben i weekenden!";
                return View();
            }
            AppointmentCaller appointmentCaller = new AppointmentCaller();
            var appointments = appointmentCaller.GetByDate(date, Session["PractitionerId"] as string);
            ViewBag.SelectedDate = date.ToShortDateString();
            return View(appointments);
        }

        /// <summary>
        /// BookTime takes the two datetime objects and uses the API to book a time for the selected date, practitioner and time span selected.
        /// Concurrency issues throws exception with suitable response message. The 'ChoseAppointmentTime'-view is shown with the error message.
        /// </summary>
        /// <param name="startDateTime">aka apointment start time</param>
        /// <param name="endDateTime">aka apointment end time</param>
        /// <returns>The new appoinment is passed to the view if successfull</returns>
        public ActionResult BookTime(DateTime startDateTime, DateTime endDateTime)
        {
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
                TempData["ErrorMessage"] = e.Message;
                return RedirectToAction("ChooseAppointmentTime", startDateTime.Date);
            }
            return View(a); ;
        }
    }
}