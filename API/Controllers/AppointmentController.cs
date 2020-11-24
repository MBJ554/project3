using API.ApiHelpers;
using API.DAL.Interfaces;
using API.Models;
using Dapper;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace API.Controllers
{
    public class AppointmentController : ApiController
    {
        private readonly IAppointmentRepository _appointmentRepository;
        public AppointmentController(IAppointmentRepository appointmentRepository)
        {
            _appointmentRepository = appointmentRepository;
        }
        // GET: api/Appointment
        public IHttpActionResult Get()
        {
            List<Appointment> appointments = new List<Appointment>();
            var appointmentsDAL = _appointmentRepository.GetAll();
            if (appointmentsDAL.Count() == 0)
            {
                return NotFound();
            }
            foreach (var appointment in appointmentsDAL)
            {
                appointments.Add(BuildAppointment(appointment));
            }
            return Ok(appointments);
        }

        // GET: api/Appointment/GetById
        public IHttpActionResult Get(int id)
        {
            var appointmentDAL = _appointmentRepository.GetById(id);
            if (appointmentDAL != null)
            {
                return Ok(BuildAppointment(appointmentDAL));
            }
            return NotFound();
        }
        
        // GET: api/Appointment/id
        public IHttpActionResult Get(int id, [FromUri] string date)
        {
            List<Appointment> appointsments = new List<Appointment>();
            DateTime res = DateTime.Parse(date);
            var appointmentsDAL = _appointmentRepository.GetAllByPractitionerAndDate(res, id);
            if (appointmentsDAL.Count() == 0)
            {
                return NotFound();
            }
            foreach (var appointment in appointmentsDAL)
            {
                appointsments.Add(BuildAppointment(appointment));
            }
            return Ok(appointsments);

        }

        // POST: api/Appointment
        public void Post([FromBody] Appointment appointment)
        {
            API.DAL.Models.Appointment c = BuildDalAppointment(appointment);
            _appointmentRepository.Create(c);
        }

        // DELETE: api/Appointment/5
        public bool Delete(int id)
        {
            return _appointmentRepository.Delete(id);
        }

        private Appointment BuildAppointment(API.DAL.Models.Appointment appointment)
        {
            return new Appointment 
            { 
                Id = appointment.Id,
                Startdate = appointment.Startdate,
                Enddate = appointment.Enddate,
                Practioner = ApiHelper.BuildPractitionerURL(appointment.PractionerId),
                Customer = ApiHelper.BuildCustomerURL(appointment.CustomerId)
            };
        }

        private API.DAL.Models.Appointment BuildDalAppointment(Appointment appointment) {
            
            // TODO : Fix tidkonvertiring til UTC
            return new API.DAL.Models.Appointment
            {
                Id = appointment.Id,
                Startdate = appointment.Startdate.ToLocalTime(),
                Enddate = appointment.Enddate.ToLocalTime(),
                CustomerId = int.Parse(appointment.Customer),
                PractionerId = int.Parse(appointment.Practioner)
        };


        }
    }
}
