using API.DAL.Interfaces;
using API.Models;
using System;
using System.Collections.Generic;
using System.Web.Http;

namespace API.Controllers
{
    public class RehabProgramController : ApiController
    {
        private readonly IRehabProgramRepository _rehabProgramRepository;

        public RehabProgramController(IRehabProgramRepository rehabProgramRepository)
        {
            _rehabProgramRepository = rehabProgramRepository;
        }

        // GET: api/RehabProgram
        public IEnumerable<RehabProgram> Get()
        {
            throw new NotImplementedException();
        }

        // GET: api/RehabProgram/GetById
        public RehabProgram Get(int id)
        {
            throw new NotImplementedException();
        }

        // POST: api/RehabProgram
        public void Post([FromBody] RehabProgram rehabProgram)
        {
            throw new NotImplementedException();
        }

        // DELETE: api/RehabProgram/5
        public RehabProgram Delete(int id)
        {
            throw new NotImplementedException();
        }
    }
}