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
    public class ClinicCaller : ICaller<Clinic>
    {
        private RestClient client;

        public ClinicCaller()
        {
            client = new RestClient(ConfigurationManager.AppSettings["ProjectApi"]);
        }

        public void Create(Clinic obj)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Clinic>> GetAll()
        {
            var request = new RestRequest("api/clinic", Method.GET);
            var response = await client.ExecuteAsync<List<Clinic>>(request);
            return response.Data;
        }

        public Clinic GetById(string id)
        {
            var request = new RestRequest( id, Method.GET);
            var response = client.Execute<Clinic>(request);
            return response.Data;
        }

        public void Update(Clinic obj)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Clinic> GetAllSync()
        {
            var request = new RestRequest("api/clinic", Method.GET);
            var response = client.Execute<List<Clinic>>(request);
            return response.Data;
        }

    }
}
