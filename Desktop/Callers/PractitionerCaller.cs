﻿using Desktop.Models;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Threading.Tasks;

namespace Desktop.Callers
{
    public class PractitionerCaller : ICaller<Practitioner>
    {
        private RestClient client;

        public PractitionerCaller()
        {
            client = new RestClient(ConfigurationManager.AppSettings["ProjectApi"]);
        }

        public void Create(Practitioner obj)
        {
            var request = new RestRequest("api/practitioner", Method.POST);
            request.AddJsonBody(obj);
            var response = client.Execute(request);
            if (response.StatusCode != System.Net.HttpStatusCode.OK)
            {
                throw new Exception();
            }
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Practitioner>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Practitioner GetById(string id)
        {
            throw new NotImplementedException();
        }

        public void Update(Practitioner obj)
        {
            throw new NotImplementedException();
        }

        internal object GetByEmail(string email)
        {
            var request = new RestRequest("api/practitioner" + email, Method.GET);
            var response = client.Execute<Customer>(request);
            return response.Data;
        }
    }
}