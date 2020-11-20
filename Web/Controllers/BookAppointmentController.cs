﻿using System;
using System.Collections.Generic;
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
            return View();
        }

       
        public async Task<ActionResult> ChooseAppointmentTime(DateTime AppointmentDate)
        {
            AppointmentCaller ac = new AppointmentCaller();
            var getBookedAppointments = ac.GetByDate(AppointmentDate);

            await Task.WhenAll(getBookedAppointments);
            // List<Appointment> bookedAppointments = new List<Appointment>();
            // Appointment bookedAppointment = new Appointment();
            // bookedAppointment.Startdate = DateTime.Today.AddHours(10);
            List<Appointment> bookedAppointments = getBookedAppointments.Result; 
            
            
            List<Appointment> allowedAppointments = new List<Appointment>();
            for (int i = 0; i < 14; i++)
            {
                Appointment a = new Appointment();
                a.Startdate = DateTime.Today.AddHours(8 + (i * 0.50));
                a.Enddate = DateTime.Today.AddHours(8 + (i * 0.5 + 0.5));

                foreach (Appointment bookedA in bookedAppointments)
                {
                    if (a.Startdate != bookedA.Startdate) {
                        allowedAppointments.Add(a);
                    }
                    
                }
                
            }
            


            ViewBag.Appointments = allowedAppointments;

            return View(allowedAppointments);
        }

        public ActionResult BookTime(DateTime startDate) {


            return null;
        }


    }
}