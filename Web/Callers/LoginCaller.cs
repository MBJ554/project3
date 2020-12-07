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




        public async Task<bool> GetByLogin(string UserName, string Password)
        {

            //var request1 = new RestRequest("/customer", Method.GET);
            //var response1 = await client.ExecuteAsync <List<Customer>>(request1);
            Customer c = new Customer();
            c.Password = Password;
            c.Email = UserName;
            var request = new RestRequest("/customer/" + 1 + "/" + "Login", Method.POST);
            request.AddJsonBody(c);
            var response = await client.ExecuteAsync<bool>(request);
            return response.Data;
        }

       
    }
}