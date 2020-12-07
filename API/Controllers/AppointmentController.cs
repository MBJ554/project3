using API.ApiHelpers;
using API.DAL.Exceptions;
using API.DAL.Interfaces;
using API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
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
        public IHttpActionResult Post([FromBody] Appointment appointment)
        {
            API.DAL.Models.Appointment c = BuildDalAppointment(appointment);
            try
            {
                _appointmentRepository.Create(c);
            }
            catch (DataAccessException e)
            {
                return Content(HttpStatusCode.Conflict, e.Message);
                //throw e;
            }

            return Ok();
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
                Practitioner = ApiHelper.BuildPractitionerURL(appointment.PractitionerId),
                Customer = ApiHelper.BuildCustomerURL(appointment.CustomerId)
            };
        }

        private API.DAL.Models.Appointment BuildDalAppointment(Appointment appointment)
        {

            // TODO : Fix tidkonvertiring til UTC
            return new API.DAL.Models.Appointment
            {
                Id = appointment.Id,
                Startdate = appointment.Startdate.ToLocalTime(),
                Enddate = appointment.Enddate.ToLocalTime(),
                CustomerId = int.Parse(appointment.Customer),
                PractitionerId = int.Parse(appointment.Practitioner)
            };


        }
    }
}
