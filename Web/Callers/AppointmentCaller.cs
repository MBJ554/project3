using RestSharp;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using Web.CustomAuthorize;
using Web.Models;

namespace Web.Callers
{   
    public class AppointmentCaller : ICaller<Appointment>
    {
        private RestClient client;

        /// <summary>
        /// Creates the RestClient object using 'ProjectApi' path from web.config
        /// </summary>
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

        /// <summary>
        /// Get all appointments using API
        /// </summary>
        /// <returns>IEnumerable<Appointment></returns>
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

        /// <summary>
        /// Get appointments by date for a specific practioner using the API
        /// </summary>
        /// <param name="appointmentDate">Appointment date</param>
        /// <param name="id">Practioner ID</param>
        /// <returns></returns>
        public async Task<IEnumerable<Appointment>> GetByDate(DateTime appointmentDate, string id)
        {
            var request = new RestRequest("api/appointment/"+ id, Method.GET);
            request.AddParameter("date", appointmentDate.ToString());
            var response = await client.ExecuteAsync<List<Appointment>>(request);
            return response.Data;
        }

        /// <summary>
        /// Book appoinment time and date using the API
        /// </summary>
        /// <param name="a">Appointment object</param>
        public void BookTime(Appointment a)
        {
            var request = new RestRequest("api/appointment", Method.POST);
            request.AddJsonBody(a);
            var response = client.Execute(request);
            if (response.StatusCode == System.Net.HttpStatusCode.Conflict)
            {
                throw new Exception(response.ErrorMessage);
            }
        }
    }
}