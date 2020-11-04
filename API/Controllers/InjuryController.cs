using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace API.Controllers
{
    public class InjuryController : ApiController
    {
        // GET: api/Injury
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Injury/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Injury
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Injury/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Injury/5
        public void Delete(int id)
        {
        }
    }
}
