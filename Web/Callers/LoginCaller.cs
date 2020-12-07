﻿using RestSharp;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using Web.Models;

namespace Web.Callers
{
    public class LoginCaller
    {

        private RestClient client;


        public LoginCaller()
        {

            client = new RestClient(ConfigurationManager.AppSettings["ProjectApi"]);
        }




        public async Task<bool> GetByLogin(string email, string password)
        {
            var request = new RestRequest("customer/" + email + "/" + password, Method.POST);    
            var response = await client.ExecuteAsync<bool>(request);
            
            return response.Data;
        }

       
    }
}