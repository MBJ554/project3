using RestSharp;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Script.Serialization;
using Web.Models;

namespace Web.Callers
{
    public class AppointmentCaller : ICaller<Appointment>
    {

        private RestClient client;


        public AppointmentCaller()
        {

            client = new RestClient(ConfigurationManager.AppSettings["ProjectApi2"]);
        }

        public void Create(Appointment obj)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Appointment>> GetAll()
        {
            var request = new RestRequest("api/appointment", Method.GET);
            var response = await client.ExecuteAsync<List<Appointment>>(request);
            return response.Data;
        }

        public Appointment GetById(int id)
        {
           throw new NotImplementedException();
        }

        public void Update(Appointment obj)
        {
            throw new NotImplementedException();
        }

        //TODO change to IEnumerable
        public async Task<List<Appointment>> GetByDate(DateTime appointmentDate)
        {
            var request = new RestRequest("api/appointment/"+ 1, Method.GET);
            request.AddParameter("date", appointmentDate.ToString());
            var response = await client.ExecuteAsync<List<Appointment>>(request);
            return response.Data;
        }

        public void BookTime(Appointment a)
        {

           

            var request = new RestRequest("api/appointment", Method.POST);
            request.AddJsonBody(a);
            var response = client.Execute(request);
            if (response.StatusCode == System.Net.HttpStatusCode.Conflict)
            {
                throw new Exception("Der er sket en fejl");
            }
        }
    }
}