using RestSharp;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using Web.Models;

namespace Web.Callers
{
    public class AppointmentCaller : ICaller<Appointment>
    {

        private RestClient client;


        public AppointmentCaller()
        {

            client = new RestClient(ConfigurationManager.AppSettings["ProjectApi"]);
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
            var request = new RestRequest("Appointment", Method.GET);
            var response = await Task.Run(() => client.Execute<List<Appointment>>(request));
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

        public async Task<List<Appointment>> GetByDate(DateTime appointmentDate)
        {


            var request = new RestRequest("Appointment/"+ 1, Method.GET);
            request.AddParameter("date", appointmentDate.ToString());
            var response = await Task.Run(() => client.Execute<List<Appointment>>(request));
            return response.Data;
        }
    }
}