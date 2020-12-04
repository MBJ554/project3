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
    public class CityCaller : ICaller<City>
    {

        



        private RestClient CityClient;
        

        public CityCaller() {

            CityClient = new RestClient(ConfigurationManager.AppSettings["ByApi"]);
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
           
            var request = new RestRequest("/postnumre", Method.GET);
            var response = await CityClient.ExecuteAsync<List<City>>(request);
            if (response.StatusCode != System.Net.HttpStatusCode.OK) {
                RestClient LocalApi = new RestClient(ConfigurationManager.AppSettings["ProjectApi"]);
                var request2 = new RestRequest("/zipCode", Method.GET);
                var response2 = await LocalApi.ExecuteAsync<List<City>>(request);
                return response2.Data;
            }
            

            return response.Data;
        }

        public City GetById(int id)
        {
            throw new NotImplementedException();
        }

        public  async Task<City> GetByZipCode(string id)
        {
            City c;
            var request = new RestRequest("/postnumre/" + id, Method.GET);
            var response = await CityClient.ExecuteAsync<City>(request);

            if (response.StatusCode != System.Net.HttpStatusCode.OK)
            {
                RestClient LocalApi = new RestClient(ConfigurationManager.AppSettings["ProjectApi"]);
                var request2 = new RestRequest("/zipCode/" + id, Method.GET);
                var response2 = await LocalApi.ExecuteAsync<City>(request2);
                c = response2.Data;
            }
            else {
                c = response.Data;
            }
            return c;
        }



        public void Update(City obj)
        {
            throw new NotImplementedException();
        }

        public  IEnumerable<City> GetAllSync()
        {
            var request = new RestRequest("/postnumre", Method.GET);
            var response = CityClient.Execute<List<City>>(request);
            return response.Data;
        }

    }
}
