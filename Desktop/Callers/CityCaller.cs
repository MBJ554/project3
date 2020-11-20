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

        



        private RestClient client;
        

        public CityCaller() {

            client = new RestClient(ConfigurationManager.AppSettings["ByApi"]);
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
            var response = await Task.Run(() => client.Execute<List<City>>(request));
            return response.Data;
        }

        public City GetById(int id)
        {
            throw new NotImplementedException();
        }

        public City GetByZipCode(string id)
        {
            var request = new RestRequest("/postnumre/" + id, Method.GET);
            var response = client.Execute<City>(request);
            return response.Data;
        }



        public void Update(City obj)
        {
            throw new NotImplementedException();
        }

        public  IEnumerable<City> GetAllSync()
        {
            var request = new RestRequest("/postnumre", Method.GET);
            var response = client.Execute<List<City>>(request);
            return response.Data;
        }

    }
}
