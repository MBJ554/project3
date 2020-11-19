using Microsoft.Graph;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication.Callers;
using WebApplication.Models;

namespace WebApplication.Controllers
{
    public class BookAppointmentController : Controller
    {
        // GET: BookAppointment
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult index(Date date) {
            AppointmentCaller ac = new AppointmentCaller();
            ac.GetAll();
            List<Appointment> appointments = new List<Appointment>();
            for (int i = 0; i < 14; i++) {
                Appointment a = new Appointment();
                a.Startdate = DateTime.Today.AddHours(8 + (i*0.50));
                a.Enddate = DateTime.Today.AddHours(8 + (i * 0.5 + 0.5));
                appointments.Add(a);
            }
            ViewBag.Appointments = appointments;

            return View();
        }


    }
}