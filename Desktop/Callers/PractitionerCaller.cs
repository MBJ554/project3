using Desktop.Models;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Desktop.Callers
{
    public class PractitionerCaller : ICaller<Practitioner>
    {
        private RestClient client;

        public PractitionerCaller()
        {
            client = new RestClient(ConfigurationManager.AppSettings["ProjectApi"]);
        }

        public void Create(Practitioner obj)
        {
            var request = new RestRequest("api/practitioner", Method.POST);
            request.AddJsonBody(obj);
            var response = client.Execute(request);
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Practitioner>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Practitioner GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(Practitioner obj)
        {
            throw new NotImplementedException();
        }
    }
}
