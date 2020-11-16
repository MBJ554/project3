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
    class CityCaller : ICaller<City>
    {

        



        private RestClient client;
        

        public CityCaller() {

            client = new RestClient(ConfigurationManager.AppSettings["ProjectApi"]);
        }


        public void Create(City obj)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<City> GetAll()
        {
            var request = new RestRequest("city", Method.GET);
            var response = client.Execute<List<City>>(request);
            return response.Data;
        }

        public City GetById(int id)
        {
            throw new NotImplementedException();
        }

        public City GetByZipCode(string id)
        {
            throw new NotImplementedException();
        }



        public void Update(City obj)
        {
            throw new NotImplementedException();
        }
    }
}
