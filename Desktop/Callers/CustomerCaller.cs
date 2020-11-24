﻿using Desktop.Models;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;

namespace Desktop.Callers
{
    public class CustomerCaller : ICaller<Customer>
    {

        private RestClient client;


        public CustomerCaller()
        {

            client = new RestClient(ConfigurationManager.AppSettings["ProjectApi"]);
        }

        public void Create(Customer obj)
        {
            var request = new RestRequest("/Customer", Method.POST);      
            request.AddJsonBody(obj);
            var response = client.Execute(request);          
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Customer>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Customer GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(Customer obj)
        {
            throw new NotImplementedException();
        }
    }
}
