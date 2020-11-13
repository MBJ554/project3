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
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Practitioner/5
        public Practitioner Get(int id)
        {
            //return _practitionerRepository.GetById(id);
            return null;
        }

        // POST: api/Practitioner
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Practitioner/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Practitioner/5
        public void Delete(int id)
        {
        }

        private Practitioner buildPractitioner(API.DAL.Models.Practitioner practitioner)
        {
            return new Practitioner
            {
                Id = practitioner.Id,
                //Clinic = 
            };
        }
    }
}
