using Desktop.Models;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Desktop.Callers
{
    class AppointmentCaller
    {
        private RestClient client;

        public AppointmentCaller()
        {
            client = new RestClient(ConfigurationManager.AppSettings["ProjectApi"]);
        }

        public IEnumerable<Appointment> GetAllAppointmentsByPractitionerId(int Id)
        {
            var request = new RestRequest("api/appointment/get/" + Id, Method.GET);
            request.AddParameter("date", DateTime.Today.ToString());
            var response = client.Execute<List<Appointment>> (request);       
            return response.Data;
        }
    }
}
