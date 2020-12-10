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
    public class LoginCaller
    {

        private RestClient client;


        public LoginCaller()
        {
            client = new RestClient(ConfigurationManager.AppSettings["ProjectApi"]);
        }

        public Practitioner GetByLogin(string email, string password)
        {
            var request = new RestRequest("api/practitioner/" + email + "/" + password, Method.GET);
            var response = client.Execute<Practitioner>(request);
            return response.Data;
        }
    }
}
