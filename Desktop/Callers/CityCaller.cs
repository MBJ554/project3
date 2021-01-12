using Desktop.Models;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Threading.Tasks;

namespace Desktop.Callers
{
    public class CityCaller : ICaller<City>
    {
        private RestClient ProjectClient;

        public CityCaller()
        {
            ProjectClient = new RestClient(ConfigurationManager.AppSettings["ProjectApi"]);
        }

        public CityCaller(string Url)
        {
            ProjectClient = new RestClient(Url);
        }

        public void Create(City obj)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<City>> GetAll()
        {
            var request = new RestRequest("api/City", Method.GET);
            var response = await ProjectClient.ExecuteAsync<List<City>>(request);
            if (response.StatusCode != System.Net.HttpStatusCode.OK)
            {
                RestClient CityClient = new RestClient(ConfigurationManager.AppSettings["ByApi"]);
                var request2 = new RestRequest("api/postnumre", Method.GET);
                var response2 = await CityClient.ExecuteAsync<List<City>>(request);
                return response2.Data;
            }
            return response.Data;
        }

        public City GetById(string id)
        {
            throw new NotImplementedException();
        }

        public async Task<City> GetByZipCode(string id)
        {
            var request = new RestRequest("api/City/" + id, Method.GET);
            var response = await ProjectClient.ExecuteAsync<City>(request);

            if (response.StatusCode != System.Net.HttpStatusCode.OK)
            {
                RestClient CityClient = new RestClient(ConfigurationManager.AppSettings["ByApi"]);
                var request2 = new RestRequest("api/postnumre/" + id, Method.GET);
                var response2 = await CityClient.ExecuteAsync<City>(request2);
                return response2.Data;
            }
           
            return response.Data;
        }

        public void Update(City obj)
        {
            throw new NotImplementedException();
        }

    }
}