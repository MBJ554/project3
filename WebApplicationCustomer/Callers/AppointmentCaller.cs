﻿using RestSharp;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using WebApplication.Models;

namespace WebApplication.Callers
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

        public IEnumerable<Appointment> GetAll()
        {
            var request = new RestRequest("Appointment", Method.GET);
            var response = client.Execute<List<Appointment>>(request);
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

        public List<Appointment> GetByDate(DateTime appointmentDate)
        {
            var request = new RestRequest("Appointment/" + appointmentDate, Method.GET);
            var response = client.Execute<List<Appointment>>(request);
            return response.Data;
        }
    }
}