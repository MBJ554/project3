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
    public class ClinicController : ApiController
    {
  
        private readonly IClinicRepository _clinicRepository;

        public ClinicController(IClinicRepository clinicRepository)
        {
            _clinicRepository = clinicRepository;
        }

        /// <summary>
        /// Gets all clinics
        /// </summary>
        /// <returns>List of all clinics</returns>
        //Get: api/clinic
        public IHttpActionResult Get()
        {
            var clinics = new List<Clinic>();
            var clinicsDAL = _clinicRepository.GetAll();
            if (clinicsDAL.Count() == 0)
            {
                return NotFound();
            }
            foreach (var clinic in clinicsDAL)
            {
                clinics.Add(buildClinic(clinic));
            }
           return Ok(clinics);
        }

        /// <summary>
        /// Get a specific clinic from an id
        /// </summary>
        /// <param name="id">The id of the clinic to get</param>
        /// <returns>A clinic</returns>
        // GET: api/clinic/5
        public IHttpActionResult Get(int id)
        {
            var clinicDAL = _clinicRepository.GetById(id);
            if (clinicDAL != null)
            {
                return Ok(buildClinic(clinicDAL));
            }
            return NotFound();
        }

        /// <summary>
        /// Creates a new clinic
        /// </summary>
        /// <param name="clinic">The clinic that is being created</param>
        // POST: api/clinic
        public void Post([FromBody] API.DAL.Models.Clinic clinic)
        {
            _clinicRepository.Create(clinic);
        }

        /// <summary>
        /// Deletes a specific clinic
        /// </summary>
        /// <param name="id">The id of the clinic</param>
        /// <returns>OkResult if the clinic is deleted</returns>
        // DELETE: api/clinic/5
        public IHttpActionResult Delete(int id)
        {
            if (_clinicRepository.Delete(id))
            {
                return Ok();
            }
            return NotFound();
        }


        /// <summary>
        /// Converts clinic DAL model to clinic API model
        /// </summary>
        /// <param name="clinic">The clinic to convert</param>
        /// <returns>Converted clinic</returns>
        private Clinic buildClinic(API.DAL.Models.Clinic clinic)
        {
            return new Clinic
            {
                Id = clinic.Id,
                Name = clinic.Name,
                Address = clinic.Address,
                ZipCode = clinic.ZipCode,
                City = clinic.CityName,
                PhoneNo = clinic.PhoneNo,
                Description = clinic.Description
            };
        }
    }
}
