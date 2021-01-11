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

        /// <summary>
        /// Gets all appointments
        /// </summary>
        /// <returns>List of all Appointments</returns>
        // GET: api/Appointment
        public IHttpActionResult GetAll()
        {
            List<Appointment> appointments = new List<Appointment>();
            var appointmentsDAL = _appointmentRepository.GetAll();
            if (appointmentsDAL.Any())
            {
                foreach (var appointment in appointmentsDAL)
                {
                    appointments.Add(BuildAppointment(appointment));
                }
                return Ok(appointments);
            }
            return NotFound();
        }

        /// <summary>
        /// Gets a specific Appointment from an id
        /// </summary>
        /// <param name="id">The id of the Appointment to get</param>
        /// <returns>An Appointment</returns>
        //GET: api/appointment/5
        [Route("api/appointment/{id}")]
        public IHttpActionResult GetById(int id)
        {
            var appointmentDAL = _appointmentRepository.GetById(id);
            if (appointmentDAL != null)
            {
                return Ok(BuildAppointment(appointmentDAL));
            }
            return NotFound();
        }

        /// <summary>
        /// Get all Appointments for a specific Practitioner on a specific date
        /// </summary>
        /// <param name="id">The id of the practitioner to find appointments for</param>
        /// <param name="date">The date to find appointments on</param>
        /// <returns>List of all appointments for a practitioner on a given date</returns>
        // GET: api/appointment/5
        [Route("api/appointment/{id}/")]
        public IHttpActionResult Get(int id, [FromUri] string date)
        {
            DateTime appointmentDate = DateTime.Parse(date);
            var appointmentsDAL = _appointmentRepository.GetAllByPractitionerAndDate(appointmentDate, id);

            List<Appointment> appointments = new List<Appointment>();
            for (int i = 0; i < 14; i++)
            {
                Appointment a = new Appointment();
                a.Startdate = appointmentDate.AddHours(8 + (i * 0.50));
                a.Enddate = appointmentDate.AddHours(8 + (i * 0.5 + 0.5));
                appointments.Add(a);
            }

            var allowedAppointments = appointments.Where(x => !appointmentsDAL.Any(y => x.Startdate == y.Startdate));
            if (allowedAppointments != null && allowedAppointments.Count() != 0)
            {
                return Ok(allowedAppointments);
            }

            return NotFound();
        }

        [Route("api/appointment/get/{id}/")]
        public IHttpActionResult GetAppointments(int id, [FromUri] string date)
        {
            DateTime appointmentDate = DateTime.Parse(date);
            var appointmentsDAL = _appointmentRepository.GetAllByPractitionerAndDate(appointmentDate, id);
            var appointments = appointmentsDAL.Select(BuildAppointment).ToList();

            if (appointments.Count() != 0)
            {
                return Ok(appointments);
            }

            return NotFound();
        }

        /// <summary>
        /// Creates a new Appointment
        /// </summary>
        /// <param name="appointment">The appointment that is being created</param>
        /// <returns>OkResult if the appointment was created successfully </returns>
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
            }
            return Ok();
        }

        /// <summary>
        /// Deletes a specific Appointment
        /// </summary>
        /// <param name="id">The id of the Appointment</param>
        /// <returns></returns>
        // DELETE: api/Appointment/5
        public IHttpActionResult Delete(int id)
        {
            if (_appointmentRepository.Delete(id))
            {
                return Ok();
            }
            return NotFound();
        }

        /// <summary>
        /// Converts appointment DAL model to appointment API model.
        /// </summary>
        /// <param name="appointment">Appointment to convert</param>
        /// <returns>Converted appointment</returns>
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

        /// <summary>
        /// Converts appointment API model to appointment DAL model
        /// </summary>
        /// <param name="appointment">Appointment to convert</param>
        /// <returns>Converted appointment</returns>
        private API.DAL.Models.Appointment BuildDalAppointment(Appointment appointment)
        {
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