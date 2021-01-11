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
    class AppointmentCaller : IAppointmentCaller
    {
        private RestClient client;

        public AppointmentCaller()
        {
            client = new RestClient(ConfigurationManager.AppSettings["ProjectApi"]);
        }

        public async Task<ObservableCollection<Appointment>> GetAllAppointmentsByPractitionerId(int Id)
        {
            var request = new RestRequest("/appointment/" + Id, Method.GET);
            request.AddParameter("date", DateTime.Today);
            var response = await client.ExecuteAsync<ObservableCollection<Appointment>> (request);       
            return response.Data;
        }
    }
}
