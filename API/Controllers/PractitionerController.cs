using API.ApiHelpers;
using API.DAL.Interfaces;
using API.DAL.Repositories;
using API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace API.Controllers
{
    public class PractitionerController : ApiController
    {
        private readonly IPractitionerRepository _practitionerRepository;
        public PractitionerController(IPractitionerRepository practitionerRepository)
        {
            _practitionerRepository = practitionerRepository;
        }

        /// <summary>
        /// Get all practitioners
        /// </summary>
        /// <returns>List of all practitioners</returns>
        // GET: api/practitioner
        public IHttpActionResult Get()
        {
            List<Practitioner> practitioners = new List<Practitioner>();
            var practitionersDAL = _practitionerRepository.GetAll();
            if (practitionersDAL.Count() == 0)
            {
                return NotFound();
            }
            foreach (var practitioner in practitionersDAL)
            {
                    practitioners.Add(buildPractitioner(practitioner));
            }
            return Ok(practitioners);
        }

        /// <summary>
        /// Gets a specific practitioner from an id
        /// </summary>
        /// <param name="id">The id of the practitioner to get</param>
        /// <returns>A practitioner</returns>
        // GET: api/practitioner/5
        public IHttpActionResult Get(int id)
        {
            var practitioner = _practitionerRepository.GetById(id);
            if (practitioner != null)
            {
                return Ok(buildPractitioner(practitioner));
            }
            return NotFound();
        }

        /// <summary>
        /// Creates a new practitioner
        /// </summary>
        /// <param name="practitioner">The practitioner that is being created</param>
        // POST: api/Practitioner
        public void Post([FromBody] API.DAL.Models.Practitioner practitioner)
        {
            _practitionerRepository.Create(practitioner);
        }

        /// <summary>
        /// Updates a specific practitioner
        /// </summary>
        /// <param name="practitioner">The practitioner to be updated</param>
        // PUT: api/Practitioner/5
        [HttpPut]
        public void Put([FromBody] API.DAL.Models.Practitioner practitioner)
        {
            _practitionerRepository.Update(practitioner);
        }

        /// <summary>
        /// Gets a practitioner from email and password
        /// </summary>
        /// <param name="login">contains the email and password</param>
        /// <returns>The customer who logged in</returns>
        [HttpPost]
        [Route("api/practitioner/login")]
        public IHttpActionResult Login([FromBody] LoginInfo login)
        {
            var practitioner = _practitionerRepository.IsAuthorized(login.Email, login.Password);
            if (practitioner != null)
            {
                return Ok(buildPractitioner(practitioner));
            }
            return NotFound();
        }

        /// <summary>
        /// Deletes a specific practitioner
        /// </summary>
        /// <param name="id">The id of the practitioner</param>
        /// <returns>OkResult if the practitioner is deleted</returns>
        // DELETE: api/Practitioner/5
        public IHttpActionResult Delete(int id)
        {
            if (_practitionerRepository.Delete(id))
            {
                return Ok();
            }
            return NotFound();
        }

        /// <summary>
        /// Converts practitioner DAL model to practitioner API model, and adds api urls instead of ids
        /// </summary>
        /// <param name="practitioner">Practitioner to convert</param>
        /// <returns>Converted practitioner</returns>
        private Practitioner buildPractitioner(API.DAL.Models.Practitioner practitioner)
        {
            return new Practitioner
            {
                Id = practitioner.Id,
                Clinic = practitioner.ClinicId != 0 ? ApiHelper.BuildClinicURL(practitioner.ClinicId) : null,
                FirstName = practitioner.FirstName,
                LastName = practitioner.LastName,
                PhoneNo = practitioner.PhoneNo,
                Email = practitioner.Email
            };
        }
    }
}
