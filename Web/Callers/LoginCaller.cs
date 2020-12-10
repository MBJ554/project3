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
    public class LoginCaller
    {

        private RestClient client;


        public LoginCaller()
        {
            client = new RestClient(ConfigurationManager.AppSettings["ProjectApi"]);
        }

        public async Task<Customer> GetByLogin(string email, string password)
        {
            var request = new RestRequest("api/customer/" + email + "/" + password, Method.GET);
            var response = await client.ExecuteAsync<Customer>(request);
            return response.Data;
        }
    }
}