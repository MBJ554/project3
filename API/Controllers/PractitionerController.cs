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
        // GET: api/Practitioner
        public IHttpActionResult Get()
        {
            List<Practitioner> practitioners = new List<Practitioner>();
            var pratitionersDAL = _practitionerRepository.GetAll();
            foreach (var practitioner in pratitionersDAL)
            {
                if (practitioner != null)
                {
                    practitioners.Add(buildPractitioner(practitioner));
                }
            }
            if (practitioners.Count == 0)
            {
                return NotFound();
            }
            return Ok(practitioners);
        }

        // GET: api/Practitioner/5
        public IHttpActionResult Get(int id)
        {
            var practitioner = _practitionerRepository.GetById(id);
            if (practitioner != null)
            {
                return Ok(buildPractitioner(practitioner));
            }
            return NotFound();
        }

        // POST: api/Practitioner
        public void Post([FromBody] API.DAL.Models.Practitioner practitioner)
        {
            _practitionerRepository.Create(practitioner);
        }

        // PUT: api/Practitioner/5
        public void Put(int id, [FromBody] API.DAL.Models.Practitioner practitioner)
        {
            _practitionerRepository.Update(practitioner);
        }

        // DELETE: api/Practitioner/5
        public void Delete(int id)
        {
            _practitionerRepository.Delete(id);
        }

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
