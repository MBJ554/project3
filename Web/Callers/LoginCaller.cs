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

            client = new RestClient(ConfigurationManager.AppSettings["ProjectApi2"]);
        }

        public async Task<Customer> GetByLogin(string email, string password)
        {
            var request = new RestRequest("api/customer/" + email + "/" + password, Method.GET);
            var response = await client.ExecuteAsync<Customer>(request);
            return response.Data;
        }


        //var request1 = new RestRequest("/customer", Method.GET);
        //var response1 = await client.ExecuteAsync <List<Customer>>(request1);
        //Customer c = new Customer();
        //c.Password = Password;
        //c.Email = UserName;
        //request.AddJsonBody(c);

    }
}